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
	/// Entity class which represents the entity 'RescheduleCancelDisposition'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class RescheduleCancelDispositionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventAppointmentCancellationLogEntity> _eventAppointmentCancellationLog;
		private EntityCollection<EventAppointmentChangeLogEntity> _eventAppointmentChangeLog;
		private EntityCollection<CustomerRegistrationNotesEntity> _customerRegistrationNotesCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventAppointmentChangeLog;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAppointmentChangeLog_;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAppointmentChangeLog;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventAppointmentChangeLog;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAppointmentChangeLog;
		private EntityCollection<RefundRequestEntity> _refundRequestCollectionViaEventAppointmentCancellationLog;
		private LookupEntity _lookup;

		
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
			/// <summary>Member name EventAppointmentCancellationLog</summary>
			public static readonly string EventAppointmentCancellationLog = "EventAppointmentCancellationLog";
			/// <summary>Member name EventAppointmentChangeLog</summary>
			public static readonly string EventAppointmentChangeLog = "EventAppointmentChangeLog";
			/// <summary>Member name CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog = "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name EventCustomersCollectionViaEventAppointmentChangeLog</summary>
			public static readonly string EventCustomersCollectionViaEventAppointmentChangeLog = "EventCustomersCollectionViaEventAppointmentChangeLog";
			/// <summary>Member name EventCustomersCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string EventCustomersCollectionViaEventAppointmentCancellationLog = "EventCustomersCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name EventsCollectionViaEventAppointmentChangeLog_</summary>
			public static readonly string EventsCollectionViaEventAppointmentChangeLog_ = "EventsCollectionViaEventAppointmentChangeLog_";
			/// <summary>Member name EventsCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string EventsCollectionViaEventAppointmentCancellationLog = "EventsCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name EventsCollectionViaEventAppointmentChangeLog</summary>
			public static readonly string EventsCollectionViaEventAppointmentChangeLog = "EventsCollectionViaEventAppointmentChangeLog";
			/// <summary>Member name LookupCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string LookupCollectionViaEventAppointmentCancellationLog = "LookupCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name LookupCollectionViaEventAppointmentChangeLog</summary>
			public static readonly string LookupCollectionViaEventAppointmentChangeLog = "LookupCollectionViaEventAppointmentChangeLog";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAppointmentCancellationLog = "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAppointmentChangeLog</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAppointmentChangeLog = "OrganizationRoleUserCollectionViaEventAppointmentChangeLog";
			/// <summary>Member name RefundRequestCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string RefundRequestCollectionViaEventAppointmentCancellationLog = "RefundRequestCollectionViaEventAppointmentCancellationLog";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static RescheduleCancelDispositionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public RescheduleCancelDispositionEntity():base("RescheduleCancelDispositionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public RescheduleCancelDispositionEntity(IEntityFields2 fields):base("RescheduleCancelDispositionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this RescheduleCancelDispositionEntity</param>
		public RescheduleCancelDispositionEntity(IValidator validator):base("RescheduleCancelDispositionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for RescheduleCancelDisposition which data should be fetched into this RescheduleCancelDisposition object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RescheduleCancelDispositionEntity(System.Int64 id):base("RescheduleCancelDispositionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for RescheduleCancelDisposition which data should be fetched into this RescheduleCancelDisposition object</param>
		/// <param name="validator">The custom validator object for this RescheduleCancelDispositionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RescheduleCancelDispositionEntity(System.Int64 id, IValidator validator):base("RescheduleCancelDispositionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected RescheduleCancelDispositionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventAppointmentCancellationLog = (EntityCollection<EventAppointmentCancellationLogEntity>)info.GetValue("_eventAppointmentCancellationLog", typeof(EntityCollection<EventAppointmentCancellationLogEntity>));
				_eventAppointmentChangeLog = (EntityCollection<EventAppointmentChangeLogEntity>)info.GetValue("_eventAppointmentChangeLog", typeof(EntityCollection<EventAppointmentChangeLogEntity>));
				_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = (EntityCollection<CustomerRegistrationNotesEntity>)info.GetValue("_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<CustomerRegistrationNotesEntity>));
				_eventCustomersCollectionViaEventAppointmentChangeLog = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventAppointmentChangeLog", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaEventAppointmentChangeLog_ = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAppointmentChangeLog_", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventAppointmentChangeLog = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAppointmentChangeLog", typeof(EntityCollection<EventsEntity>));
				_lookupCollectionViaEventAppointmentCancellationLog = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventAppointmentChangeLog = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventAppointmentChangeLog", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaEventAppointmentCancellationLog = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventAppointmentChangeLog = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAppointmentChangeLog", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_refundRequestCollectionViaEventAppointmentCancellationLog = (EntityCollection<RefundRequestEntity>)info.GetValue("_refundRequestCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<RefundRequestEntity>));
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((RescheduleCancelDispositionFieldIndex)fieldIndex)
			{
				case RescheduleCancelDispositionFieldIndex.LookupId:
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
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "EventAppointmentCancellationLog":
					this.EventAppointmentCancellationLog.Add((EventAppointmentCancellationLogEntity)entity);
					break;
				case "EventAppointmentChangeLog":
					this.EventAppointmentChangeLog.Add((EventAppointmentChangeLogEntity)entity);
					break;
				case "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog":
					this.CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog.Add((CustomerRegistrationNotesEntity)entity);
					this.CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventAppointmentChangeLog":
					this.EventCustomersCollectionViaEventAppointmentChangeLog.IsReadOnly = false;
					this.EventCustomersCollectionViaEventAppointmentChangeLog.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventAppointmentChangeLog.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventAppointmentCancellationLog":
					this.EventCustomersCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.EventCustomersCollectionViaEventAppointmentCancellationLog.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventAppointmentChangeLog_":
					this.EventsCollectionViaEventAppointmentChangeLog_.IsReadOnly = false;
					this.EventsCollectionViaEventAppointmentChangeLog_.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAppointmentChangeLog_.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventAppointmentCancellationLog":
					this.EventsCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.EventsCollectionViaEventAppointmentCancellationLog.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventAppointmentChangeLog":
					this.EventsCollectionViaEventAppointmentChangeLog.IsReadOnly = false;
					this.EventsCollectionViaEventAppointmentChangeLog.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAppointmentChangeLog.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventAppointmentCancellationLog":
					this.LookupCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.LookupCollectionViaEventAppointmentCancellationLog.Add((LookupEntity)entity);
					this.LookupCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventAppointmentChangeLog":
					this.LookupCollectionViaEventAppointmentChangeLog.IsReadOnly = false;
					this.LookupCollectionViaEventAppointmentChangeLog.Add((LookupEntity)entity);
					this.LookupCollectionViaEventAppointmentChangeLog.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog":
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentChangeLog":
					this.OrganizationRoleUserCollectionViaEventAppointmentChangeLog.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAppointmentChangeLog.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAppointmentChangeLog.IsReadOnly = true;
					break;
				case "RefundRequestCollectionViaEventAppointmentCancellationLog":
					this.RefundRequestCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.RefundRequestCollectionViaEventAppointmentCancellationLog.Add((RefundRequestEntity)entity);
					this.RefundRequestCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
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
			return RescheduleCancelDispositionEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.LookupEntityUsingLookupId);
					break;
				case "EventAppointmentCancellationLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId);
					break;
				case "EventAppointmentChangeLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId);
					break;
				case "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.CustomerRegistrationNotesEntityUsingNoteId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventAppointmentChangeLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAppointmentChangeLog_":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.EventsEntityUsingOldEventId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.EventsEntityUsingEventId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAppointmentChangeLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.EventsEntityUsingNewEventId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.LookupEntityUsingReasonId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventAppointmentChangeLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.LookupEntityUsingReasonId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentChangeLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "RefundRequestCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId, "RescheduleCancelDispositionEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.RefundRequestEntityUsingRefundRequestId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
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
				case "EventAppointmentCancellationLog":
					this.EventAppointmentCancellationLog.Add((EventAppointmentCancellationLogEntity)relatedEntity);
					break;
				case "EventAppointmentChangeLog":
					this.EventAppointmentChangeLog.Add((EventAppointmentChangeLogEntity)relatedEntity);
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
				case "EventAppointmentCancellationLog":
					base.PerformRelatedEntityRemoval(this.EventAppointmentCancellationLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventAppointmentChangeLog":
					base.PerformRelatedEntityRemoval(this.EventAppointmentChangeLog, relatedEntity, signalRelatedEntityManyToOne);
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

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventAppointmentCancellationLog);
			toReturn.Add(this.EventAppointmentChangeLog);

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
				info.AddValue("_eventAppointmentCancellationLog", ((_eventAppointmentCancellationLog!=null) && (_eventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventAppointmentCancellationLog:null);
				info.AddValue("_eventAppointmentChangeLog", ((_eventAppointmentChangeLog!=null) && (_eventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_eventAppointmentChangeLog:null);
				info.AddValue("_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog", ((_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog!=null) && (_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_eventCustomersCollectionViaEventAppointmentChangeLog", ((_eventCustomersCollectionViaEventAppointmentChangeLog!=null) && (_eventCustomersCollectionViaEventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventAppointmentChangeLog:null);
				info.AddValue("_eventCustomersCollectionViaEventAppointmentCancellationLog", ((_eventCustomersCollectionViaEventAppointmentCancellationLog!=null) && (_eventCustomersCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_eventsCollectionViaEventAppointmentChangeLog_", ((_eventsCollectionViaEventAppointmentChangeLog_!=null) && (_eventsCollectionViaEventAppointmentChangeLog_.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAppointmentChangeLog_:null);
				info.AddValue("_eventsCollectionViaEventAppointmentCancellationLog", ((_eventsCollectionViaEventAppointmentCancellationLog!=null) && (_eventsCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_eventsCollectionViaEventAppointmentChangeLog", ((_eventsCollectionViaEventAppointmentChangeLog!=null) && (_eventsCollectionViaEventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAppointmentChangeLog:null);
				info.AddValue("_lookupCollectionViaEventAppointmentCancellationLog", ((_lookupCollectionViaEventAppointmentCancellationLog!=null) && (_lookupCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_lookupCollectionViaEventAppointmentChangeLog", ((_lookupCollectionViaEventAppointmentChangeLog!=null) && (_lookupCollectionViaEventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventAppointmentChangeLog:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAppointmentCancellationLog", ((_organizationRoleUserCollectionViaEventAppointmentCancellationLog!=null) && (_organizationRoleUserCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAppointmentChangeLog", ((_organizationRoleUserCollectionViaEventAppointmentChangeLog!=null) && (_organizationRoleUserCollectionViaEventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAppointmentChangeLog:null);
				info.AddValue("_refundRequestCollectionViaEventAppointmentCancellationLog", ((_refundRequestCollectionViaEventAppointmentCancellationLog!=null) && (_refundRequestCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_refundRequestCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(RescheduleCancelDispositionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(RescheduleCancelDispositionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new RescheduleCancelDispositionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAppointmentCancellationLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentCancellationLogFields.SubReasonId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAppointmentChangeLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentChangeLogFields.SubReasonId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerRegistrationNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventAppointmentChangeLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAppointmentChangeLog_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAppointmentChangeLog_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAppointmentChangeLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventAppointmentChangeLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAppointmentChangeLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RefundRequest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundRequestCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RefundRequestCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.Id, "RescheduleCancelDispositionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.LookupId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.RescheduleCancelDispositionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._customerRegistrationNotesCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAppointmentChangeLog_);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._refundRequestCollectionViaEventAppointmentCancellationLog);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventAppointmentCancellationLog = (EntityCollection<EventAppointmentCancellationLogEntity>) collectionsQueue.Dequeue();
			this._eventAppointmentChangeLog = (EntityCollection<EventAppointmentChangeLogEntity>) collectionsQueue.Dequeue();
			this._customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = (EntityCollection<CustomerRegistrationNotesEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventAppointmentChangeLog = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAppointmentChangeLog_ = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAppointmentChangeLog = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventAppointmentCancellationLog = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventAppointmentChangeLog = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAppointmentCancellationLog = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAppointmentChangeLog = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._refundRequestCollectionViaEventAppointmentCancellationLog = (EntityCollection<RefundRequestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._eventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._customerRegistrationNotesCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAppointmentChangeLog_ != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._refundRequestCollectionViaEventAppointmentCancellationLog != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAppointmentCancellationLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAppointmentChangeLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentChangeLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))) : null);
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
			toReturn.Add("EventAppointmentCancellationLog", _eventAppointmentCancellationLog);
			toReturn.Add("EventAppointmentChangeLog", _eventAppointmentChangeLog);
			toReturn.Add("CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog", _customerRegistrationNotesCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("EventCustomersCollectionViaEventAppointmentChangeLog", _eventCustomersCollectionViaEventAppointmentChangeLog);
			toReturn.Add("EventCustomersCollectionViaEventAppointmentCancellationLog", _eventCustomersCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("EventsCollectionViaEventAppointmentChangeLog_", _eventsCollectionViaEventAppointmentChangeLog_);
			toReturn.Add("EventsCollectionViaEventAppointmentCancellationLog", _eventsCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("EventsCollectionViaEventAppointmentChangeLog", _eventsCollectionViaEventAppointmentChangeLog);
			toReturn.Add("LookupCollectionViaEventAppointmentCancellationLog", _lookupCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("LookupCollectionViaEventAppointmentChangeLog", _lookupCollectionViaEventAppointmentChangeLog);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog", _organizationRoleUserCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAppointmentChangeLog", _organizationRoleUserCollectionViaEventAppointmentChangeLog);
			toReturn.Add("RefundRequestCollectionViaEventAppointmentCancellationLog", _refundRequestCollectionViaEventAppointmentCancellationLog);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventAppointmentCancellationLog!=null)
			{
				_eventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_eventAppointmentChangeLog!=null)
			{
				_eventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog!=null)
			{
				_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventAppointmentChangeLog!=null)
			{
				_eventCustomersCollectionViaEventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventAppointmentCancellationLog!=null)
			{
				_eventCustomersCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAppointmentChangeLog_!=null)
			{
				_eventsCollectionViaEventAppointmentChangeLog_.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAppointmentCancellationLog!=null)
			{
				_eventsCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAppointmentChangeLog!=null)
			{
				_eventsCollectionViaEventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventAppointmentCancellationLog!=null)
			{
				_lookupCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventAppointmentChangeLog!=null)
			{
				_lookupCollectionViaEventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAppointmentCancellationLog!=null)
			{
				_organizationRoleUserCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAppointmentChangeLog!=null)
			{
				_organizationRoleUserCollectionViaEventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_refundRequestCollectionViaEventAppointmentCancellationLog!=null)
			{
				_refundRequestCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventAppointmentCancellationLog = null;
			_eventAppointmentChangeLog = null;
			_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = null;
			_eventCustomersCollectionViaEventAppointmentChangeLog = null;
			_eventCustomersCollectionViaEventAppointmentCancellationLog = null;
			_eventsCollectionViaEventAppointmentChangeLog_ = null;
			_eventsCollectionViaEventAppointmentCancellationLog = null;
			_eventsCollectionViaEventAppointmentChangeLog = null;
			_lookupCollectionViaEventAppointmentCancellationLog = null;
			_lookupCollectionViaEventAppointmentChangeLog = null;
			_organizationRoleUserCollectionViaEventAppointmentCancellationLog = null;
			_organizationRoleUserCollectionViaEventAppointmentChangeLog = null;
			_refundRequestCollectionViaEventAppointmentCancellationLog = null;
			_lookup = null;

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

			_fieldsCustomProperties.Add("LookupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DisplayName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RelativeOrder", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DataRecorderCreatorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", RescheduleCancelDispositionEntity.Relations.LookupEntityUsingLookupId, true, signalRelatedEntity, "RescheduleCancelDisposition", resetFKFields, new int[] { (int)RescheduleCancelDispositionFieldIndex.LookupId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", RescheduleCancelDispositionEntity.Relations.LookupEntityUsingLookupId, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this RescheduleCancelDispositionEntity</param>
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
		public  static RescheduleCancelDispositionRelations Relations
		{
			get	{ return new RescheduleCancelDispositionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAppointmentCancellationLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAppointmentCancellationLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventAppointmentCancellationLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAppointmentCancellationLog")[0], (int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, 0, null, null, null, null, "EventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAppointmentChangeLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAppointmentChangeLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventAppointmentChangeLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentChangeLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAppointmentChangeLog")[0], (int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.EventAppointmentChangeLogEntity, 0, null, null, null, null, "EventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerRegistrationNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, 0, null, null, GetRelationsForField("CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog"), null, "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventAppointmentChangeLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventAppointmentChangeLog"), null, "EventCustomersCollectionViaEventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventAppointmentCancellationLog"), null, "EventCustomersCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAppointmentChangeLog_
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAppointmentChangeLog_"), null, "EventsCollectionViaEventAppointmentChangeLog_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAppointmentCancellationLog"), null, "EventsCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAppointmentChangeLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAppointmentChangeLog"), null, "EventsCollectionViaEventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventAppointmentCancellationLog"), null, "LookupCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventAppointmentChangeLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventAppointmentChangeLog"), null, "LookupCollectionViaEventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog"), null, "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAppointmentChangeLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentChangeLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAppointmentChangeLog"), null, "OrganizationRoleUserCollectionViaEventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundRequest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundRequestCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RescheduleCancelDispositionEntity.Relations.EventAppointmentCancellationLogEntityUsingSubReasonId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.RefundRequestEntity, 0, null, null, GetRelationsForField("RefundRequestCollectionViaEventAppointmentCancellationLog"), null, "RefundRequestCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return RescheduleCancelDispositionEntity.CustomProperties;}
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
			get { return RescheduleCancelDispositionEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity RescheduleCancelDisposition<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRescheduleCancelDisposition"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)RescheduleCancelDispositionFieldIndex.Id, true); }
			set	{ SetValue((int)RescheduleCancelDispositionFieldIndex.Id, value); }
		}

		/// <summary> The LookupId property of the Entity RescheduleCancelDisposition<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRescheduleCancelDisposition"."LookupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LookupId
		{
			get { return (System.Int64)GetValue((int)RescheduleCancelDispositionFieldIndex.LookupId, true); }
			set	{ SetValue((int)RescheduleCancelDispositionFieldIndex.LookupId, value); }
		}

		/// <summary> The Alias property of the Entity RescheduleCancelDisposition<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRescheduleCancelDisposition"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)RescheduleCancelDispositionFieldIndex.Alias, true); }
			set	{ SetValue((int)RescheduleCancelDispositionFieldIndex.Alias, value); }
		}

		/// <summary> The DisplayName property of the Entity RescheduleCancelDisposition<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRescheduleCancelDisposition"."DisplayName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String DisplayName
		{
			get { return (System.String)GetValue((int)RescheduleCancelDispositionFieldIndex.DisplayName, true); }
			set	{ SetValue((int)RescheduleCancelDispositionFieldIndex.DisplayName, value); }
		}

		/// <summary> The Description property of the Entity RescheduleCancelDisposition<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRescheduleCancelDisposition"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)RescheduleCancelDispositionFieldIndex.Description, true); }
			set	{ SetValue((int)RescheduleCancelDispositionFieldIndex.Description, value); }
		}

		/// <summary> The RelativeOrder property of the Entity RescheduleCancelDisposition<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRescheduleCancelDisposition"."RelativeOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RelativeOrder
		{
			get { return (System.Int32)GetValue((int)RescheduleCancelDispositionFieldIndex.RelativeOrder, true); }
			set	{ SetValue((int)RescheduleCancelDispositionFieldIndex.RelativeOrder, value); }
		}

		/// <summary> The DateCreated property of the Entity RescheduleCancelDisposition<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRescheduleCancelDisposition"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)RescheduleCancelDispositionFieldIndex.DateCreated, true); }
			set	{ SetValue((int)RescheduleCancelDispositionFieldIndex.DateCreated, value); }
		}

		/// <summary> The DataRecorderCreatorId property of the Entity RescheduleCancelDisposition<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRescheduleCancelDisposition"."DataRecorderCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 DataRecorderCreatorId
		{
			get { return (System.Int64)GetValue((int)RescheduleCancelDispositionFieldIndex.DataRecorderCreatorId, true); }
			set	{ SetValue((int)RescheduleCancelDispositionFieldIndex.DataRecorderCreatorId, value); }
		}

		/// <summary> The IsActive property of the Entity RescheduleCancelDisposition<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRescheduleCancelDisposition"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)RescheduleCancelDispositionFieldIndex.IsActive, true); }
			set	{ SetValue((int)RescheduleCancelDispositionFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAppointmentCancellationLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAppointmentCancellationLogEntity))]
		public virtual EntityCollection<EventAppointmentCancellationLogEntity> EventAppointmentCancellationLog
		{
			get
			{
				if(_eventAppointmentCancellationLog==null)
				{
					_eventAppointmentCancellationLog = new EntityCollection<EventAppointmentCancellationLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory)));
					_eventAppointmentCancellationLog.SetContainingEntityInfo(this, "RescheduleCancelDisposition");
				}
				return _eventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAppointmentChangeLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAppointmentChangeLogEntity))]
		public virtual EntityCollection<EventAppointmentChangeLogEntity> EventAppointmentChangeLog
		{
			get
			{
				if(_eventAppointmentChangeLog==null)
				{
					_eventAppointmentChangeLog = new EntityCollection<EventAppointmentChangeLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentChangeLogEntityFactory)));
					_eventAppointmentChangeLog.SetContainingEntityInfo(this, "RescheduleCancelDisposition");
				}
				return _eventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerRegistrationNotesEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerRegistrationNotesEntity))]
		public virtual EntityCollection<CustomerRegistrationNotesEntity> CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog==null)
				{
					_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory)));
					_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _customerRegistrationNotesCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventAppointmentChangeLog
		{
			get
			{
				if(_eventCustomersCollectionViaEventAppointmentChangeLog==null)
				{
					_eventCustomersCollectionViaEventAppointmentChangeLog = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventAppointmentChangeLog.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_eventCustomersCollectionViaEventAppointmentCancellationLog==null)
				{
					_eventCustomersCollectionViaEventAppointmentCancellationLog = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAppointmentChangeLog_
		{
			get
			{
				if(_eventsCollectionViaEventAppointmentChangeLog_==null)
				{
					_eventsCollectionViaEventAppointmentChangeLog_ = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAppointmentChangeLog_.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAppointmentChangeLog_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_eventsCollectionViaEventAppointmentCancellationLog==null)
				{
					_eventsCollectionViaEventAppointmentCancellationLog = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAppointmentChangeLog
		{
			get
			{
				if(_eventsCollectionViaEventAppointmentChangeLog==null)
				{
					_eventsCollectionViaEventAppointmentChangeLog = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAppointmentChangeLog.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_lookupCollectionViaEventAppointmentCancellationLog==null)
				{
					_lookupCollectionViaEventAppointmentCancellationLog = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _lookupCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventAppointmentChangeLog
		{
			get
			{
				if(_lookupCollectionViaEventAppointmentChangeLog==null)
				{
					_lookupCollectionViaEventAppointmentChangeLog = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventAppointmentChangeLog.IsReadOnly=true;
				}
				return _lookupCollectionViaEventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventAppointmentCancellationLog==null)
				{
					_organizationRoleUserCollectionViaEventAppointmentCancellationLog = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventAppointmentChangeLog
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventAppointmentChangeLog==null)
				{
					_organizationRoleUserCollectionViaEventAppointmentChangeLog = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventAppointmentChangeLog.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RefundRequestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RefundRequestEntity))]
		public virtual EntityCollection<RefundRequestEntity> RefundRequestCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_refundRequestCollectionViaEventAppointmentCancellationLog==null)
				{
					_refundRequestCollectionViaEventAppointmentCancellationLog = new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory)));
					_refundRequestCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _refundRequestCollectionViaEventAppointmentCancellationLog;
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
							_lookup.UnsetRelatedEntity(this, "RescheduleCancelDisposition");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "RescheduleCancelDisposition");
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
			get { return (int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity; }
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
