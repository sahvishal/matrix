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
	/// Entity class which represents the entity 'Tag'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TagEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerCallQueueCallAttemptEntity> _customerCallQueueCallAttempt;
		private EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity> _preAssessmentCustomerCallQueueCallAttempt;
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomerCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<CallsEntity> _callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
		private EntityCollection<CallsEntity> _callsCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerCallQueueCallAttempt;
		private LookupEntity _lookup;
		private LookupEntity _lookup_;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name CustomerCallQueueCallAttempt</summary>
			public static readonly string CustomerCallQueueCallAttempt = "CustomerCallQueueCallAttempt";
			/// <summary>Member name PreAssessmentCustomerCallQueueCallAttempt</summary>
			public static readonly string PreAssessmentCustomerCallQueueCallAttempt = "PreAssessmentCustomerCallQueueCallAttempt";
			/// <summary>Member name CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt = "CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt</summary>
			public static readonly string CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt = "CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt";
			/// <summary>Member name CallsCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string CallsCollectionViaCustomerCallQueueCallAttempt = "CallsCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt</summary>
			public static readonly string CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = "CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt";
			/// <summary>Member name CustomerProfileCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string CustomerProfileCollectionViaCustomerCallQueueCallAttempt = "CustomerProfileCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt</summary>
			public static readonly string OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = "OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt = "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TagEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TagEntity():base("TagEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TagEntity(IEntityFields2 fields):base("TagEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TagEntity</param>
		public TagEntity(IValidator validator):base("TagEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="tagId">PK value for Tag which data should be fetched into this Tag object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TagEntity(System.Int64 tagId):base("TagEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TagId = tagId;
		}

		/// <summary> CTor</summary>
		/// <param name="tagId">PK value for Tag which data should be fetched into this Tag object</param>
		/// <param name="validator">The custom validator object for this TagEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TagEntity(System.Int64 tagId, IValidator validator):base("TagEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TagId = tagId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TagEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerCallQueueCallAttempt = (EntityCollection<CustomerCallQueueCallAttemptEntity>)info.GetValue("_customerCallQueueCallAttempt", typeof(EntityCollection<CustomerCallQueueCallAttemptEntity>));
				_preAssessmentCustomerCallQueueCallAttempt = (EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>)info.GetValue("_preAssessmentCustomerCallQueueCallAttempt", typeof(EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>));
				_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<CallQueueCustomerEntity>));
				_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<CallsEntity>)info.GetValue("_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt", typeof(EntityCollection<CallsEntity>));
				_callsCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CallsEntity>)info.GetValue("_callsCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<CallsEntity>));
				_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<CustomerProfileEntity>));
				_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup_ = (LookupEntity)info.GetValue("_lookup_", typeof(LookupEntity));
				if(_lookup_!=null)
				{
					_lookup_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TagFieldIndex)fieldIndex)
			{
				case TagFieldIndex.Source:
					DesetupSyncLookup(true, false);
					break;
				case TagFieldIndex.CallStatus:
					DesetupSyncLookup_(true, false);
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
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "CustomerCallQueueCallAttempt":
					this.CustomerCallQueueCallAttempt.Add((CustomerCallQueueCallAttemptEntity)entity);
					break;
				case "PreAssessmentCustomerCallQueueCallAttempt":
					this.PreAssessmentCustomerCallQueueCallAttempt.Add((PreAssessmentCustomerCallQueueCallAttemptEntity)entity);
					break;
				case "CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt":
					this.CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt.Add((CallQueueCustomerEntity)entity);
					this.CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					this.CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Add((CallsEntity)entity);
					this.CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "CallsCollectionViaCustomerCallQueueCallAttempt":
					this.CallsCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CallsCollectionViaCustomerCallQueueCallAttempt.Add((CallsEntity)entity);
					this.CallsCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					this.CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerCallQueueCallAttempt":
					this.CustomerProfileCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerCallQueueCallAttempt.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					this.OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt":
					this.OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
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
			return TagEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Lookup":
					toReturn.Add(TagEntity.Relations.LookupEntityUsingSource);
					break;
				case "Lookup_":
					toReturn.Add(TagEntity.Relations.LookupEntityUsingCallStatus);
					break;
				case "CustomerCallQueueCallAttempt":
					toReturn.Add(TagEntity.Relations.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId);
					break;
				case "PreAssessmentCustomerCallQueueCallAttempt":
					toReturn.Add(TagEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId);
					break;
				case "CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(TagEntity.Relations.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId, "TagEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					toReturn.Add(TagEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId, "TagEntity__", "PreAssessmentCustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.CallsEntityUsingCallId, "PreAssessmentCustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "CallsCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(TagEntity.Relations.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId, "TagEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.CallsEntityUsingCallId, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					toReturn.Add(TagEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId, "TagEntity__", "PreAssessmentCustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.CustomerProfileEntityUsingCustomerId, "PreAssessmentCustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(TagEntity.Relations.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId, "TagEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					toReturn.Add(TagEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId, "TagEntity__", "PreAssessmentCustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "PreAssessmentCustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(TagEntity.Relations.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId, "TagEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
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
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "CustomerCallQueueCallAttempt":
					this.CustomerCallQueueCallAttempt.Add((CustomerCallQueueCallAttemptEntity)relatedEntity);
					break;
				case "PreAssessmentCustomerCallQueueCallAttempt":
					this.PreAssessmentCustomerCallQueueCallAttempt.Add((PreAssessmentCustomerCallQueueCallAttemptEntity)relatedEntity);
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
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "CustomerCallQueueCallAttempt":
					base.PerformRelatedEntityRemoval(this.CustomerCallQueueCallAttempt, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreAssessmentCustomerCallQueueCallAttempt":
					base.PerformRelatedEntityRemoval(this.PreAssessmentCustomerCallQueueCallAttempt, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerCallQueueCallAttempt);
			toReturn.Add(this.PreAssessmentCustomerCallQueueCallAttempt);

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
				info.AddValue("_customerCallQueueCallAttempt", ((_customerCallQueueCallAttempt!=null) && (_customerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_customerCallQueueCallAttempt:null);
				info.AddValue("_preAssessmentCustomerCallQueueCallAttempt", ((_preAssessmentCustomerCallQueueCallAttempt!=null) && (_preAssessmentCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_preAssessmentCustomerCallQueueCallAttempt:null);
				info.AddValue("_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt", ((_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt!=null) && (_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt", ((_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null) && (_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt:null);
				info.AddValue("_callsCollectionViaCustomerCallQueueCallAttempt", ((_callsCollectionViaCustomerCallQueueCallAttempt!=null) && (_callsCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_callsCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt", ((_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null) && (_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt:null);
				info.AddValue("_customerProfileCollectionViaCustomerCallQueueCallAttempt", ((_customerProfileCollectionViaCustomerCallQueueCallAttempt!=null) && (_customerProfileCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt", ((_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null) && (_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt", ((_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt!=null) && (_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TagFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TagFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TagRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerCallQueueCallAttempt' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerCallQueueCallAttemptFields.NotInterestedReasonId, null, ComparisonOperator.Equal, this.TagId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreAssessmentCustomerCallQueueCallAttempt' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreAssessmentCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreAssessmentCustomerCallQueueCallAttemptFields.NotInterestedReasonId, null, ComparisonOperator.Equal, this.TagId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TagFields.TagId, null, ComparisonOperator.Equal, this.TagId, "TagEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Calls' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TagFields.TagId, null, ComparisonOperator.Equal, this.TagId, "TagEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Calls' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallsCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallsCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TagFields.TagId, null, ComparisonOperator.Equal, this.TagId, "TagEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TagFields.TagId, null, ComparisonOperator.Equal, this.TagId, "TagEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TagFields.TagId, null, ComparisonOperator.Equal, this.TagId, "TagEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TagFields.TagId, null, ComparisonOperator.Equal, this.TagId, "TagEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TagFields.TagId, null, ComparisonOperator.Equal, this.TagId, "TagEntity__"));
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
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.CallStatus));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.TagEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._preAssessmentCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._callQueueCustomerCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._callsCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerCallQueueCallAttempt);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerCallQueueCallAttempt = (EntityCollection<CustomerCallQueueCallAttemptEntity>) collectionsQueue.Dequeue();
			this._preAssessmentCustomerCallQueueCallAttempt = (EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomerCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<CallsEntity>) collectionsQueue.Dequeue();
			this._callsCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CallsEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._preAssessmentCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._callQueueCustomerCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._callsCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerCallQueueCallAttempt != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerCallQueueCallAttemptEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreAssessmentCustomerCallQueueCallAttemptEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
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
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("CustomerCallQueueCallAttempt", _customerCallQueueCallAttempt);
			toReturn.Add("PreAssessmentCustomerCallQueueCallAttempt", _preAssessmentCustomerCallQueueCallAttempt);
			toReturn.Add("CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt", _callQueueCustomerCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt", _callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			toReturn.Add("CallsCollectionViaCustomerCallQueueCallAttempt", _callsCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt", _customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			toReturn.Add("CustomerProfileCollectionViaCustomerCallQueueCallAttempt", _customerProfileCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt", _organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt", _organizationRoleUserCollectionViaCustomerCallQueueCallAttempt);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerCallQueueCallAttempt!=null)
			{
				_customerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_preAssessmentCustomerCallQueueCallAttempt!=null)
			{
				_preAssessmentCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null)
			{
				_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_callsCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_callsCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null)
			{
				_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_customerProfileCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null)
			{
				_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerCallQueueCallAttempt = null;
			_preAssessmentCustomerCallQueueCallAttempt = null;
			_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt = null;
			_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt = null;
			_callsCollectionViaCustomerCallQueueCallAttempt = null;
			_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = null;
			_customerProfileCollectionViaCustomerCallQueueCallAttempt = null;
			_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = null;
			_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = null;
			_lookup = null;
			_lookup_ = null;

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

			_fieldsCustomProperties.Add("TagId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Source", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsSystemDefined", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsHealthPlanTag", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ForAppointmentConfirmation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ForWarmTransfer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ForPreAssessment", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", TagEntity.Relations.LookupEntityUsingSource, true, signalRelatedEntity, "Tag", resetFKFields, new int[] { (int)TagFieldIndex.Source } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", TagEntity.Relations.LookupEntityUsingSource, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", TagEntity.Relations.LookupEntityUsingCallStatus, true, signalRelatedEntity, "Tag_", resetFKFields, new int[] { (int)TagFieldIndex.CallStatus } );		
			_lookup_ = null;
		}

		/// <summary> setups the sync logic for member _lookup_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup_(IEntity2 relatedEntity)
		{
			if(_lookup_!=relatedEntity)
			{
				DesetupSyncLookup_(true, true);
				_lookup_ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", TagEntity.Relations.LookupEntityUsingCallStatus, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TagEntity</param>
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
		public  static TagRelations Relations
		{
			get	{ return new TagRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerCallQueueCallAttempt' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerCallQueueCallAttempt
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerCallQueueCallAttemptEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerCallQueueCallAttempt")[0], (int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.CustomerCallQueueCallAttemptEntity, 0, null, null, null, null, "CustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreAssessmentCustomerCallQueueCallAttempt' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreAssessmentCustomerCallQueueCallAttemptEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreAssessmentCustomerCallQueueCallAttempt")[0], (int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.PreAssessmentCustomerCallQueueCallAttemptEntity, 0, null, null, null, null, "PreAssessmentCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = TagEntity.Relations.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, GetRelationsForField("CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt"), null, "CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Calls' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = TagEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId;
				intermediateRelation.SetAliases(string.Empty, "PreAssessmentCustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, GetRelationsForField("CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt"), null, "CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Calls' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallsCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = TagEntity.Relations.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, GetRelationsForField("CallsCollectionViaCustomerCallQueueCallAttempt"), null, "CallsCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = TagEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId;
				intermediateRelation.SetAliases(string.Empty, "PreAssessmentCustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt"), null, "CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = TagEntity.Relations.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerCallQueueCallAttempt"), null, "CustomerProfileCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = TagEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId;
				intermediateRelation.SetAliases(string.Empty, "PreAssessmentCustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt"), null, "OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = TagEntity.Relations.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt"), null, "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.TagEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TagEntity.CustomProperties;}
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
			get { return TagEntity.FieldsCustomProperties;}
		}

		/// <summary> The TagId property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."TagId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TagId
		{
			get { return (System.Int64)GetValue((int)TagFieldIndex.TagId, true); }
			set	{ SetValue((int)TagFieldIndex.TagId, value); }
		}

		/// <summary> The Source property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."Source"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Source
		{
			get { return (System.Int64)GetValue((int)TagFieldIndex.Source, true); }
			set	{ SetValue((int)TagFieldIndex.Source, value); }
		}

		/// <summary> The Name property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)TagFieldIndex.Name, true); }
			set	{ SetValue((int)TagFieldIndex.Name, value); }
		}

		/// <summary> The Alias property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)TagFieldIndex.Alias, true); }
			set	{ SetValue((int)TagFieldIndex.Alias, value); }
		}

		/// <summary> The IsActive property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)TagFieldIndex.IsActive, true); }
			set	{ SetValue((int)TagFieldIndex.IsActive, value); }
		}

		/// <summary> The IsSystemDefined property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."IsSystemDefined"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsSystemDefined
		{
			get { return (System.Boolean)GetValue((int)TagFieldIndex.IsSystemDefined, true); }
			set	{ SetValue((int)TagFieldIndex.IsSystemDefined, value); }
		}

		/// <summary> The IsHealthPlanTag property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."IsHealthPlanTag"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsHealthPlanTag
		{
			get { return (System.Boolean)GetValue((int)TagFieldIndex.IsHealthPlanTag, true); }
			set	{ SetValue((int)TagFieldIndex.IsHealthPlanTag, value); }
		}

		/// <summary> The ForAppointmentConfirmation property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."ForAppointmentConfirmation"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ForAppointmentConfirmation
		{
			get { return (System.Boolean)GetValue((int)TagFieldIndex.ForAppointmentConfirmation, true); }
			set	{ SetValue((int)TagFieldIndex.ForAppointmentConfirmation, value); }
		}

		/// <summary> The CallStatus property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."CallStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CallStatus
		{
			get { return (Nullable<System.Int64>)GetValue((int)TagFieldIndex.CallStatus, false); }
			set	{ SetValue((int)TagFieldIndex.CallStatus, value); }
		}

		/// <summary> The ForWarmTransfer property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."ForWarmTransfer"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ForWarmTransfer
		{
			get { return (System.Boolean)GetValue((int)TagFieldIndex.ForWarmTransfer, true); }
			set	{ SetValue((int)TagFieldIndex.ForWarmTransfer, value); }
		}

		/// <summary> The ForPreAssessment property of the Entity Tag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTag"."ForPreAssessment"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> ForPreAssessment
		{
			get { return (Nullable<System.Boolean>)GetValue((int)TagFieldIndex.ForPreAssessment, false); }
			set	{ SetValue((int)TagFieldIndex.ForPreAssessment, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerCallQueueCallAttemptEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerCallQueueCallAttemptEntity))]
		public virtual EntityCollection<CustomerCallQueueCallAttemptEntity> CustomerCallQueueCallAttempt
		{
			get
			{
				if(_customerCallQueueCallAttempt==null)
				{
					_customerCallQueueCallAttempt = new EntityCollection<CustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerCallQueueCallAttemptEntityFactory)));
					_customerCallQueueCallAttempt.SetContainingEntityInfo(this, "Tag");
				}
				return _customerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreAssessmentCustomerCallQueueCallAttemptEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreAssessmentCustomerCallQueueCallAttemptEntity))]
		public virtual EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity> PreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				if(_preAssessmentCustomerCallQueueCallAttempt==null)
				{
					_preAssessmentCustomerCallQueueCallAttempt = new EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreAssessmentCustomerCallQueueCallAttemptEntityFactory)));
					_preAssessmentCustomerCallQueueCallAttempt.SetContainingEntityInfo(this, "Tag");
				}
				return _preAssessmentCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _callQueueCustomerCollectionViaCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallsEntity))]
		public virtual EntityCollection<CallsEntity> CallsCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				if(_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt==null)
				{
					_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt = new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory)));
					_callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _callsCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallsEntity))]
		public virtual EntityCollection<CallsEntity> CallsCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_callsCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_callsCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory)));
					_callsCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _callsCollectionViaCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				if(_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt==null)
				{
					_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_customerProfileCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_customerProfileCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				if(_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt==null)
				{
					_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerCallQueueCallAttempt;
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
							_lookup.UnsetRelatedEntity(this, "Tag");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Tag");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup_
		{
			get
			{
				return _lookup_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup_(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup_ != null)
						{
							_lookup_.UnsetRelatedEntity(this, "Tag_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Tag_");
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
			get { return (int)Falcon.Data.EntityType.TagEntity; }
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
