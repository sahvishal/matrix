///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:51
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
	/// Entity class which represents the entity 'CallCenterTeam'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CallCenterTeamEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallCenterAgentTeamEntity> _callCenterAgentTeam;
		private EntityCollection<CallCenterAgentTeamLogEntity> _callCenterAgentTeamLog;
		private EntityCollection<HealthPlanCriteriaTeamAssignmentEntity> _healthPlanCriteriaTeamAssignment;
		private EntityCollection<HealthPlanCallQueueCriteriaEntity> _healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallCenterAgentTeamLog__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallCenterAgentTeam;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallCenterAgentTeamLog;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallCenterAgentTeamLog_;
		private LookupEntity _lookup;
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
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CallCenterAgentTeam</summary>
			public static readonly string CallCenterAgentTeam = "CallCenterAgentTeam";
			/// <summary>Member name CallCenterAgentTeamLog</summary>
			public static readonly string CallCenterAgentTeamLog = "CallCenterAgentTeamLog";
			/// <summary>Member name HealthPlanCriteriaTeamAssignment</summary>
			public static readonly string HealthPlanCriteriaTeamAssignment = "HealthPlanCriteriaTeamAssignment";
			/// <summary>Member name HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment</summary>
			public static readonly string HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment = "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__ = "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallCenterAgentTeam</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallCenterAgentTeam = "OrganizationRoleUserCollectionViaCallCenterAgentTeam";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallCenterAgentTeamLog</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallCenterAgentTeamLog = "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_ = "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CallCenterTeamEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CallCenterTeamEntity():base("CallCenterTeamEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CallCenterTeamEntity(IEntityFields2 fields):base("CallCenterTeamEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CallCenterTeamEntity</param>
		public CallCenterTeamEntity(IValidator validator):base("CallCenterTeamEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CallCenterTeam which data should be fetched into this CallCenterTeam object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallCenterTeamEntity(System.Int64 id):base("CallCenterTeamEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CallCenterTeam which data should be fetched into this CallCenterTeam object</param>
		/// <param name="validator">The custom validator object for this CallCenterTeamEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallCenterTeamEntity(System.Int64 id, IValidator validator):base("CallCenterTeamEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CallCenterTeamEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callCenterAgentTeam = (EntityCollection<CallCenterAgentTeamEntity>)info.GetValue("_callCenterAgentTeam", typeof(EntityCollection<CallCenterAgentTeamEntity>));
				_callCenterAgentTeamLog = (EntityCollection<CallCenterAgentTeamLogEntity>)info.GetValue("_callCenterAgentTeamLog", typeof(EntityCollection<CallCenterAgentTeamLogEntity>));
				_healthPlanCriteriaTeamAssignment = (EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>)info.GetValue("_healthPlanCriteriaTeamAssignment", typeof(EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>));
				_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment = (EntityCollection<HealthPlanCallQueueCriteriaEntity>)info.GetValue("_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment", typeof(EntityCollection<HealthPlanCallQueueCriteriaEntity>));
				_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallCenterAgentTeamLog__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallCenterAgentTeamLog__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallCenterAgentTeam = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallCenterAgentTeam", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallCenterAgentTeamLog = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallCenterAgentTeamLog", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallCenterAgentTeamLog_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallCenterAgentTeamLog_", typeof(EntityCollection<OrganizationRoleUserEntity>));
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

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CallCenterTeamFieldIndex)fieldIndex)
			{
				case CallCenterTeamFieldIndex.TypeId:
					DesetupSyncLookup(true, false);
					break;
				case CallCenterTeamFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CallCenterTeamFieldIndex.ModifiedBy:
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
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CallCenterAgentTeam":
					this.CallCenterAgentTeam.Add((CallCenterAgentTeamEntity)entity);
					break;
				case "CallCenterAgentTeamLog":
					this.CallCenterAgentTeamLog.Add((CallCenterAgentTeamLogEntity)entity);
					break;
				case "HealthPlanCriteriaTeamAssignment":
					this.HealthPlanCriteriaTeamAssignment.Add((HealthPlanCriteriaTeamAssignmentEntity)entity);
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment":
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly = false;
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment.Add((HealthPlanCallQueueCriteriaEntity)entity);
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_":
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment":
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__":
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallCenterAgentTeam":
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeam.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeam.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeam.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog":
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeamLog.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeamLog.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeamLog.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_":
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_.IsReadOnly = true;
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
			return CallCenterTeamEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(CallCenterTeamEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(CallCenterTeamEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CallCenterTeamEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "CallCenterAgentTeam":
					toReturn.Add(CallCenterTeamEntity.Relations.CallCenterAgentTeamEntityUsingTeamId);
					break;
				case "CallCenterAgentTeamLog":
					toReturn.Add(CallCenterTeamEntity.Relations.CallCenterAgentTeamLogEntityUsingTeamId);
					break;
				case "HealthPlanCriteriaTeamAssignment":
					toReturn.Add(CallCenterTeamEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingTeamId);
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment":
					toReturn.Add(CallCenterTeamEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingTeamId, "CallCenterTeamEntity__", "HealthPlanCriteriaTeamAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaTeamAssignmentEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanCriteriaId, "HealthPlanCriteriaTeamAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_":
					toReturn.Add(CallCenterTeamEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingTeamId, "CallCenterTeamEntity__", "HealthPlanCriteriaTeamAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaTeamAssignmentEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "HealthPlanCriteriaTeamAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment":
					toReturn.Add(CallCenterTeamEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingTeamId, "CallCenterTeamEntity__", "HealthPlanCriteriaTeamAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaTeamAssignmentEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "HealthPlanCriteriaTeamAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__":
					toReturn.Add(CallCenterTeamEntity.Relations.CallCenterAgentTeamLogEntityUsingTeamId, "CallCenterTeamEntity__", "CallCenterAgentTeamLog_", JoinHint.None);
					toReturn.Add(CallCenterAgentTeamLogEntity.Relations.OrganizationRoleUserEntityUsingRemovedByOrgRoleUserId, "CallCenterAgentTeamLog_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallCenterAgentTeam":
					toReturn.Add(CallCenterTeamEntity.Relations.CallCenterAgentTeamEntityUsingTeamId, "CallCenterTeamEntity__", "CallCenterAgentTeam_", JoinHint.None);
					toReturn.Add(CallCenterAgentTeamEntity.Relations.OrganizationRoleUserEntityUsingAgentId, "CallCenterAgentTeam_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog":
					toReturn.Add(CallCenterTeamEntity.Relations.CallCenterAgentTeamLogEntityUsingTeamId, "CallCenterTeamEntity__", "CallCenterAgentTeamLog_", JoinHint.None);
					toReturn.Add(CallCenterAgentTeamLogEntity.Relations.OrganizationRoleUserEntityUsingAgentId, "CallCenterAgentTeamLog_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_":
					toReturn.Add(CallCenterTeamEntity.Relations.CallCenterAgentTeamLogEntityUsingTeamId, "CallCenterTeamEntity__", "CallCenterAgentTeamLog_", JoinHint.None);
					toReturn.Add(CallCenterAgentTeamLogEntity.Relations.OrganizationRoleUserEntityUsingAssignedByOrgRoleUserId, "CallCenterAgentTeamLog_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CallCenterAgentTeam":
					this.CallCenterAgentTeam.Add((CallCenterAgentTeamEntity)relatedEntity);
					break;
				case "CallCenterAgentTeamLog":
					this.CallCenterAgentTeamLog.Add((CallCenterAgentTeamLogEntity)relatedEntity);
					break;
				case "HealthPlanCriteriaTeamAssignment":
					this.HealthPlanCriteriaTeamAssignment.Add((HealthPlanCriteriaTeamAssignmentEntity)relatedEntity);
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
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CallCenterAgentTeam":
					base.PerformRelatedEntityRemoval(this.CallCenterAgentTeam, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallCenterAgentTeamLog":
					base.PerformRelatedEntityRemoval(this.CallCenterAgentTeamLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCriteriaTeamAssignment":
					base.PerformRelatedEntityRemoval(this.HealthPlanCriteriaTeamAssignment, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CallCenterAgentTeam);
			toReturn.Add(this.CallCenterAgentTeamLog);
			toReturn.Add(this.HealthPlanCriteriaTeamAssignment);

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
				info.AddValue("_callCenterAgentTeam", ((_callCenterAgentTeam!=null) && (_callCenterAgentTeam.Count>0) && !this.MarkedForDeletion)?_callCenterAgentTeam:null);
				info.AddValue("_callCenterAgentTeamLog", ((_callCenterAgentTeamLog!=null) && (_callCenterAgentTeamLog.Count>0) && !this.MarkedForDeletion)?_callCenterAgentTeamLog:null);
				info.AddValue("_healthPlanCriteriaTeamAssignment", ((_healthPlanCriteriaTeamAssignment!=null) && (_healthPlanCriteriaTeamAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCriteriaTeamAssignment:null);
				info.AddValue("_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment", ((_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment!=null) && (_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_", ((_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_!=null) && (_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment", ((_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment!=null) && (_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaCallCenterAgentTeamLog__", ((_organizationRoleUserCollectionViaCallCenterAgentTeamLog__!=null) && (_organizationRoleUserCollectionViaCallCenterAgentTeamLog__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallCenterAgentTeamLog__:null);
				info.AddValue("_organizationRoleUserCollectionViaCallCenterAgentTeam", ((_organizationRoleUserCollectionViaCallCenterAgentTeam!=null) && (_organizationRoleUserCollectionViaCallCenterAgentTeam.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallCenterAgentTeam:null);
				info.AddValue("_organizationRoleUserCollectionViaCallCenterAgentTeamLog", ((_organizationRoleUserCollectionViaCallCenterAgentTeamLog!=null) && (_organizationRoleUserCollectionViaCallCenterAgentTeamLog.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallCenterAgentTeamLog:null);
				info.AddValue("_organizationRoleUserCollectionViaCallCenterAgentTeamLog_", ((_organizationRoleUserCollectionViaCallCenterAgentTeamLog_!=null) && (_organizationRoleUserCollectionViaCallCenterAgentTeamLog_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallCenterAgentTeamLog_:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
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
		public bool TestOriginalFieldValueForNull(CallCenterTeamFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CallCenterTeamFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CallCenterTeamRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallCenterAgentTeam' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallCenterAgentTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterAgentTeamFields.TeamId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallCenterAgentTeamLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallCenterAgentTeamLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterAgentTeamLogFields.TeamId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCriteriaTeamAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCriteriaTeamAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCriteriaTeamAssignmentFields.TeamId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterTeamFields.Id, null, ComparisonOperator.Equal, this.Id, "CallCenterTeamEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterTeamFields.Id, null, ComparisonOperator.Equal, this.Id, "CallCenterTeamEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterTeamFields.Id, null, ComparisonOperator.Equal, this.Id, "CallCenterTeamEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallCenterAgentTeamLog__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterTeamFields.Id, null, ComparisonOperator.Equal, this.Id, "CallCenterTeamEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallCenterAgentTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallCenterAgentTeam"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterTeamFields.Id, null, ComparisonOperator.Equal, this.Id, "CallCenterTeamEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallCenterAgentTeamLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallCenterAgentTeamLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterTeamFields.Id, null, ComparisonOperator.Equal, this.Id, "CallCenterTeamEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallCenterAgentTeamLog_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterTeamFields.Id, null, ComparisonOperator.Equal, this.Id, "CallCenterTeamEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.TypeId));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CallCenterTeamEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CallCenterTeamEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callCenterAgentTeam);
			collectionsQueue.Enqueue(this._callCenterAgentTeamLog);
			collectionsQueue.Enqueue(this._healthPlanCriteriaTeamAssignment);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallCenterAgentTeamLog__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallCenterAgentTeam);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallCenterAgentTeamLog);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallCenterAgentTeamLog_);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callCenterAgentTeam = (EntityCollection<CallCenterAgentTeamEntity>) collectionsQueue.Dequeue();
			this._callCenterAgentTeamLog = (EntityCollection<CallCenterAgentTeamLogEntity>) collectionsQueue.Dequeue();
			this._healthPlanCriteriaTeamAssignment = (EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment = (EntityCollection<HealthPlanCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallCenterAgentTeamLog__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallCenterAgentTeam = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallCenterAgentTeamLog = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallCenterAgentTeamLog_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callCenterAgentTeam != null)
			{
				return true;
			}
			if (this._callCenterAgentTeamLog != null)
			{
				return true;
			}
			if (this._healthPlanCriteriaTeamAssignment != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallCenterAgentTeamLog__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallCenterAgentTeam != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallCenterAgentTeamLog != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallCenterAgentTeamLog_ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallCenterAgentTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterAgentTeamEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallCenterAgentTeamLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterAgentTeamLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaTeamAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
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
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CallCenterAgentTeam", _callCenterAgentTeam);
			toReturn.Add("CallCenterAgentTeamLog", _callCenterAgentTeamLog);
			toReturn.Add("HealthPlanCriteriaTeamAssignment", _healthPlanCriteriaTeamAssignment);
			toReturn.Add("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment", _healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_", _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment", _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__", _organizationRoleUserCollectionViaCallCenterAgentTeamLog__);
			toReturn.Add("OrganizationRoleUserCollectionViaCallCenterAgentTeam", _organizationRoleUserCollectionViaCallCenterAgentTeam);
			toReturn.Add("OrganizationRoleUserCollectionViaCallCenterAgentTeamLog", _organizationRoleUserCollectionViaCallCenterAgentTeamLog);
			toReturn.Add("OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_", _organizationRoleUserCollectionViaCallCenterAgentTeamLog_);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callCenterAgentTeam!=null)
			{
				_callCenterAgentTeam.ActiveContext = base.ActiveContext;
			}
			if(_callCenterAgentTeamLog!=null)
			{
				_callCenterAgentTeamLog.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCriteriaTeamAssignment!=null)
			{
				_healthPlanCriteriaTeamAssignment.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment!=null)
			{
				_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallCenterAgentTeamLog__!=null)
			{
				_organizationRoleUserCollectionViaCallCenterAgentTeamLog__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallCenterAgentTeam!=null)
			{
				_organizationRoleUserCollectionViaCallCenterAgentTeam.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallCenterAgentTeamLog!=null)
			{
				_organizationRoleUserCollectionViaCallCenterAgentTeamLog.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallCenterAgentTeamLog_!=null)
			{
				_organizationRoleUserCollectionViaCallCenterAgentTeamLog_.ActiveContext = base.ActiveContext;
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

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callCenterAgentTeam = null;
			_callCenterAgentTeamLog = null;
			_healthPlanCriteriaTeamAssignment = null;
			_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment = null;
			_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = null;
			_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = null;
			_organizationRoleUserCollectionViaCallCenterAgentTeamLog__ = null;
			_organizationRoleUserCollectionViaCallCenterAgentTeam = null;
			_organizationRoleUserCollectionViaCallCenterAgentTeamLog = null;
			_organizationRoleUserCollectionViaCallCenterAgentTeamLog_ = null;
			_lookup = null;
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

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallCenterTeamEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "CallCenterTeam", resetFKFields, new int[] { (int)CallCenterTeamFieldIndex.TypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallCenterTeamEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CallCenterTeamEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "CallCenterTeam_", resetFKFields, new int[] { (int)CallCenterTeamFieldIndex.ModifiedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CallCenterTeamEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallCenterTeamEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "CallCenterTeam", resetFKFields, new int[] { (int)CallCenterTeamFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallCenterTeamEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CallCenterTeamEntity</param>
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
		public  static CallCenterTeamRelations Relations
		{
			get	{ return new CallCenterTeamRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallCenterAgentTeam' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallCenterAgentTeam
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallCenterAgentTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterAgentTeamEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallCenterAgentTeam")[0], (int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.CallCenterAgentTeamEntity, 0, null, null, null, null, "CallCenterAgentTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallCenterAgentTeamLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallCenterAgentTeamLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallCenterAgentTeamLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterAgentTeamLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallCenterAgentTeamLog")[0], (int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.CallCenterAgentTeamLogEntity, 0, null, null, null, null, "CallCenterAgentTeamLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCriteriaTeamAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCriteriaTeamAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaTeamAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanCriteriaTeamAssignment")[0], (int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.HealthPlanCriteriaTeamAssignmentEntity, 0, null, null, null, null, "HealthPlanCriteriaTeamAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallCenterTeamEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingTeamId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaTeamAssignment_");
				return new PrefetchPathElement2(new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, 0, null, null, GetRelationsForField("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment"), null, "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_
		{
			get
			{
				IEntityRelation intermediateRelation = CallCenterTeamEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingTeamId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaTeamAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_"), null, "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallCenterTeamEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingTeamId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaTeamAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment"), null, "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallCenterAgentTeamLog__
		{
			get
			{
				IEntityRelation intermediateRelation = CallCenterTeamEntity.Relations.CallCenterAgentTeamLogEntityUsingTeamId;
				intermediateRelation.SetAliases(string.Empty, "CallCenterAgentTeamLog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__"), null, "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallCenterAgentTeam
		{
			get
			{
				IEntityRelation intermediateRelation = CallCenterTeamEntity.Relations.CallCenterAgentTeamEntityUsingTeamId;
				intermediateRelation.SetAliases(string.Empty, "CallCenterAgentTeam_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallCenterAgentTeam"), null, "OrganizationRoleUserCollectionViaCallCenterAgentTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallCenterAgentTeamLog
		{
			get
			{
				IEntityRelation intermediateRelation = CallCenterTeamEntity.Relations.CallCenterAgentTeamLogEntityUsingTeamId;
				intermediateRelation.SetAliases(string.Empty, "CallCenterAgentTeamLog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallCenterAgentTeamLog"), null, "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallCenterAgentTeamLog_
		{
			get
			{
				IEntityRelation intermediateRelation = CallCenterTeamEntity.Relations.CallCenterAgentTeamLogEntityUsingTeamId;
				intermediateRelation.SetAliases(string.Empty, "CallCenterAgentTeamLog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_"), null, "OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CallCenterTeamEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CallCenterTeamEntity.CustomProperties;}
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
			get { return CallCenterTeamEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity CallCenterTeam<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallCenterTeam"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CallCenterTeamFieldIndex.Id, true); }
			set	{ SetValue((int)CallCenterTeamFieldIndex.Id, value); }
		}

		/// <summary> The Name property of the Entity CallCenterTeam<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallCenterTeam"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CallCenterTeamFieldIndex.Name, true); }
			set	{ SetValue((int)CallCenterTeamFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity CallCenterTeam<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallCenterTeam"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2048<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CallCenterTeamFieldIndex.Description, true); }
			set	{ SetValue((int)CallCenterTeamFieldIndex.Description, value); }
		}

		/// <summary> The TypeId property of the Entity CallCenterTeam<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallCenterTeam"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)CallCenterTeamFieldIndex.TypeId, true); }
			set	{ SetValue((int)CallCenterTeamFieldIndex.TypeId, value); }
		}

		/// <summary> The CreatedBy property of the Entity CallCenterTeam<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallCenterTeam"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)CallCenterTeamFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)CallCenterTeamFieldIndex.CreatedBy, value); }
		}

		/// <summary> The DateCreated property of the Entity CallCenterTeam<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallCenterTeam"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CallCenterTeamFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CallCenterTeamFieldIndex.DateCreated, value); }
		}

		/// <summary> The ModifiedBy property of the Entity CallCenterTeam<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallCenterTeam"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ModifiedBy
		{
			get { return (System.Int64)GetValue((int)CallCenterTeamFieldIndex.ModifiedBy, true); }
			set	{ SetValue((int)CallCenterTeamFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The DateModified property of the Entity CallCenterTeam<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallCenterTeam"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallCenterTeamFieldIndex.DateModified, false); }
			set	{ SetValue((int)CallCenterTeamFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity CallCenterTeam<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallCenterTeam"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CallCenterTeamFieldIndex.IsActive, true); }
			set	{ SetValue((int)CallCenterTeamFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallCenterAgentTeamEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallCenterAgentTeamEntity))]
		public virtual EntityCollection<CallCenterAgentTeamEntity> CallCenterAgentTeam
		{
			get
			{
				if(_callCenterAgentTeam==null)
				{
					_callCenterAgentTeam = new EntityCollection<CallCenterAgentTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterAgentTeamEntityFactory)));
					_callCenterAgentTeam.SetContainingEntityInfo(this, "CallCenterTeam");
				}
				return _callCenterAgentTeam;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallCenterAgentTeamLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallCenterAgentTeamLogEntity))]
		public virtual EntityCollection<CallCenterAgentTeamLogEntity> CallCenterAgentTeamLog
		{
			get
			{
				if(_callCenterAgentTeamLog==null)
				{
					_callCenterAgentTeamLog = new EntityCollection<CallCenterAgentTeamLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterAgentTeamLogEntityFactory)));
					_callCenterAgentTeamLog.SetContainingEntityInfo(this, "CallCenterTeam");
				}
				return _callCenterAgentTeamLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCriteriaTeamAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCriteriaTeamAssignmentEntity))]
		public virtual EntityCollection<HealthPlanCriteriaTeamAssignmentEntity> HealthPlanCriteriaTeamAssignment
		{
			get
			{
				if(_healthPlanCriteriaTeamAssignment==null)
				{
					_healthPlanCriteriaTeamAssignment = new EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaTeamAssignmentEntityFactory)));
					_healthPlanCriteriaTeamAssignment.SetContainingEntityInfo(this, "CallCenterTeam");
				}
				return _healthPlanCriteriaTeamAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCallQueueCriteriaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCallQueueCriteriaEntity))]
		public virtual EntityCollection<HealthPlanCallQueueCriteriaEntity> HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment
		{
			get
			{
				if(_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment==null)
				{
					_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment = new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory)));
					_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly=true;
				}
				return _healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaTeamAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallCenterAgentTeamLog__
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallCenterAgentTeamLog__==null)
				{
					_organizationRoleUserCollectionViaCallCenterAgentTeamLog__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallCenterAgentTeamLog__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallCenterAgentTeamLog__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallCenterAgentTeam
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallCenterAgentTeam==null)
				{
					_organizationRoleUserCollectionViaCallCenterAgentTeam = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallCenterAgentTeam.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallCenterAgentTeam;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallCenterAgentTeamLog
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallCenterAgentTeamLog==null)
				{
					_organizationRoleUserCollectionViaCallCenterAgentTeamLog = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallCenterAgentTeamLog.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallCenterAgentTeamLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallCenterAgentTeamLog_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallCenterAgentTeamLog_==null)
				{
					_organizationRoleUserCollectionViaCallCenterAgentTeamLog_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallCenterAgentTeamLog_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallCenterAgentTeamLog_;
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
							_lookup.UnsetRelatedEntity(this, "CallCenterTeam");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallCenterTeam");
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "CallCenterTeam_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallCenterTeam_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CallCenterTeam");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallCenterTeam");
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
			get { return (int)Falcon.Data.EntityType.CallCenterTeamEntity; }
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
