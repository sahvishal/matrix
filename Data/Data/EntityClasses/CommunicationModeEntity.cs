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
	/// Entity class which represents the entity 'CommunicationMode'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CommunicationModeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventsEntity> _events;
		private EntityCollection<EventTypeEntity> _eventTypeCollectionViaEvents;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaEvents;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents____;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents___;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents__;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents_;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaEvents;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents____;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents___;
		private EntityCollection<ScheduleMethodEntity> _scheduleMethodCollectionViaEvents;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name EventTypeCollectionViaEvents</summary>
			public static readonly string EventTypeCollectionViaEvents = "EventTypeCollectionViaEvents";
			/// <summary>Member name HafTemplateCollectionViaEvents</summary>
			public static readonly string HafTemplateCollectionViaEvents = "HafTemplateCollectionViaEvents";
			/// <summary>Member name LookupCollectionViaEvents</summary>
			public static readonly string LookupCollectionViaEvents = "LookupCollectionViaEvents";
			/// <summary>Member name LookupCollectionViaEvents____</summary>
			public static readonly string LookupCollectionViaEvents____ = "LookupCollectionViaEvents____";
			/// <summary>Member name LookupCollectionViaEvents___</summary>
			public static readonly string LookupCollectionViaEvents___ = "LookupCollectionViaEvents___";
			/// <summary>Member name LookupCollectionViaEvents__</summary>
			public static readonly string LookupCollectionViaEvents__ = "LookupCollectionViaEvents__";
			/// <summary>Member name LookupCollectionViaEvents_</summary>
			public static readonly string LookupCollectionViaEvents_ = "LookupCollectionViaEvents_";
			/// <summary>Member name NotesDetailsCollectionViaEvents</summary>
			public static readonly string NotesDetailsCollectionViaEvents = "NotesDetailsCollectionViaEvents";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents_ = "OrganizationRoleUserCollectionViaEvents_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents____</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents____ = "OrganizationRoleUserCollectionViaEvents____";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents__</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents__ = "OrganizationRoleUserCollectionViaEvents__";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents = "OrganizationRoleUserCollectionViaEvents";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents___</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents___ = "OrganizationRoleUserCollectionViaEvents___";
			/// <summary>Member name ScheduleMethodCollectionViaEvents</summary>
			public static readonly string ScheduleMethodCollectionViaEvents = "ScheduleMethodCollectionViaEvents";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CommunicationModeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CommunicationModeEntity():base("CommunicationModeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CommunicationModeEntity(IEntityFields2 fields):base("CommunicationModeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CommunicationModeEntity</param>
		public CommunicationModeEntity(IValidator validator):base("CommunicationModeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="communicationModeId">PK value for CommunicationMode which data should be fetched into this CommunicationMode object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CommunicationModeEntity(System.Int64 communicationModeId):base("CommunicationModeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CommunicationModeId = communicationModeId;
		}

		/// <summary> CTor</summary>
		/// <param name="communicationModeId">PK value for CommunicationMode which data should be fetched into this CommunicationMode object</param>
		/// <param name="validator">The custom validator object for this CommunicationModeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CommunicationModeEntity(System.Int64 communicationModeId, IValidator validator):base("CommunicationModeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CommunicationModeId = communicationModeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CommunicationModeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_events = (EntityCollection<EventsEntity>)info.GetValue("_events", typeof(EntityCollection<EventsEntity>));
				_eventTypeCollectionViaEvents = (EntityCollection<EventTypeEntity>)info.GetValue("_eventTypeCollectionViaEvents", typeof(EntityCollection<EventTypeEntity>));
				_hafTemplateCollectionViaEvents = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaEvents", typeof(EntityCollection<HafTemplateEntity>));
				_lookupCollectionViaEvents = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents_", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaEvents = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaEvents", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationRoleUserCollectionViaEvents_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents____ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents____", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents___ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents___", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_scheduleMethodCollectionViaEvents = (EntityCollection<ScheduleMethodEntity>)info.GetValue("_scheduleMethodCollectionViaEvents", typeof(EntityCollection<ScheduleMethodEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CommunicationModeFieldIndex)fieldIndex)
			{
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

				case "Events":
					this.Events.Add((EventsEntity)entity);
					break;
				case "EventTypeCollectionViaEvents":
					this.EventTypeCollectionViaEvents.IsReadOnly = false;
					this.EventTypeCollectionViaEvents.Add((EventTypeEntity)entity);
					this.EventTypeCollectionViaEvents.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaEvents":
					this.HafTemplateCollectionViaEvents.IsReadOnly = false;
					this.HafTemplateCollectionViaEvents.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaEvents.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents":
					this.LookupCollectionViaEvents.IsReadOnly = false;
					this.LookupCollectionViaEvents.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents____":
					this.LookupCollectionViaEvents____.IsReadOnly = false;
					this.LookupCollectionViaEvents____.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents____.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents___":
					this.LookupCollectionViaEvents___.IsReadOnly = false;
					this.LookupCollectionViaEvents___.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents___.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents__":
					this.LookupCollectionViaEvents__.IsReadOnly = false;
					this.LookupCollectionViaEvents__.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents__.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents_":
					this.LookupCollectionViaEvents_.IsReadOnly = false;
					this.LookupCollectionViaEvents_.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents_.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaEvents":
					this.NotesDetailsCollectionViaEvents.IsReadOnly = false;
					this.NotesDetailsCollectionViaEvents.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaEvents.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents_":
					this.OrganizationRoleUserCollectionViaEvents_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents____":
					this.OrganizationRoleUserCollectionViaEvents____.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents____.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents____.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents__":
					this.OrganizationRoleUserCollectionViaEvents__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents":
					this.OrganizationRoleUserCollectionViaEvents.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents___":
					this.OrganizationRoleUserCollectionViaEvents___.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents___.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents___.IsReadOnly = true;
					break;
				case "ScheduleMethodCollectionViaEvents":
					this.ScheduleMethodCollectionViaEvents.IsReadOnly = false;
					this.ScheduleMethodCollectionViaEvents.Add((ScheduleMethodEntity)entity);
					this.ScheduleMethodCollectionViaEvents.IsReadOnly = true;
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
			return CommunicationModeEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "Events":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId);
					break;
				case "EventTypeCollectionViaEvents":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.EventTypeEntityUsingEventTypeId, "Events_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaEvents":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.HafTemplateEntityUsingHafTemplateId, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateKynXml, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents____":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateHealthAssesmentFormStatus, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents___":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateMyBioCheckAssessment, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents__":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateHkynXml, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents_":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingEventCancellationReasonId, "Events_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaEvents":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.NotesDetailsEntityUsingEmrNotesId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents_":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents____":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByAdmin, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents__":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingEventActivityOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents___":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingSignOffOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "ScheduleMethodCollectionViaEvents":
					toReturn.Add(CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId, "CommunicationModeEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.ScheduleMethodEntityUsingScheduleMethodId, "Events_", string.Empty, JoinHint.None);
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

				case "Events":
					this.Events.Add((EventsEntity)relatedEntity);
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

				case "Events":
					base.PerformRelatedEntityRemoval(this.Events, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Events);

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
				info.AddValue("_events", ((_events!=null) && (_events.Count>0) && !this.MarkedForDeletion)?_events:null);
				info.AddValue("_eventTypeCollectionViaEvents", ((_eventTypeCollectionViaEvents!=null) && (_eventTypeCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_eventTypeCollectionViaEvents:null);
				info.AddValue("_hafTemplateCollectionViaEvents", ((_hafTemplateCollectionViaEvents!=null) && (_hafTemplateCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaEvents:null);
				info.AddValue("_lookupCollectionViaEvents", ((_lookupCollectionViaEvents!=null) && (_lookupCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents:null);
				info.AddValue("_lookupCollectionViaEvents____", ((_lookupCollectionViaEvents____!=null) && (_lookupCollectionViaEvents____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents____:null);
				info.AddValue("_lookupCollectionViaEvents___", ((_lookupCollectionViaEvents___!=null) && (_lookupCollectionViaEvents___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents___:null);
				info.AddValue("_lookupCollectionViaEvents__", ((_lookupCollectionViaEvents__!=null) && (_lookupCollectionViaEvents__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents__:null);
				info.AddValue("_lookupCollectionViaEvents_", ((_lookupCollectionViaEvents_!=null) && (_lookupCollectionViaEvents_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents_:null);
				info.AddValue("_notesDetailsCollectionViaEvents", ((_notesDetailsCollectionViaEvents!=null) && (_notesDetailsCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaEvents:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents_", ((_organizationRoleUserCollectionViaEvents_!=null) && (_organizationRoleUserCollectionViaEvents_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents_:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents____", ((_organizationRoleUserCollectionViaEvents____!=null) && (_organizationRoleUserCollectionViaEvents____.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents____:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents__", ((_organizationRoleUserCollectionViaEvents__!=null) && (_organizationRoleUserCollectionViaEvents__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents__:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents", ((_organizationRoleUserCollectionViaEvents!=null) && (_organizationRoleUserCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents___", ((_organizationRoleUserCollectionViaEvents___!=null) && (_organizationRoleUserCollectionViaEvents___.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents___:null);
				info.AddValue("_scheduleMethodCollectionViaEvents", ((_scheduleMethodCollectionViaEvents!=null) && (_scheduleMethodCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_scheduleMethodCollectionViaEvents:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CommunicationModeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CommunicationModeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CommunicationModeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTypeCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventTypeCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ScheduleMethod' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScheduleMethodCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ScheduleMethodCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CommunicationModeFields.CommunicationModeId, null, ComparisonOperator.Equal, this.CommunicationModeId, "CommunicationModeEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CommunicationModeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CommunicationModeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._events);
			collectionsQueue.Enqueue(this._eventTypeCollectionViaEvents);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaEvents);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents____);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents___);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents__);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents_);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaEvents);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents____);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents___);
			collectionsQueue.Enqueue(this._scheduleMethodCollectionViaEvents);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._events = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventTypeCollectionViaEvents = (EntityCollection<EventTypeEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaEvents = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaEvents = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents____ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents___ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._scheduleMethodCollectionViaEvents = (EntityCollection<ScheduleMethodEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._events != null)
			{
				return true;
			}
			if (this._eventTypeCollectionViaEvents != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaEvents != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents_ != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaEvents != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents____ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents___ != null)
			{
				return true;
			}
			if (this._scheduleMethodCollectionViaEvents != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ScheduleMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleMethodEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("Events", _events);
			toReturn.Add("EventTypeCollectionViaEvents", _eventTypeCollectionViaEvents);
			toReturn.Add("HafTemplateCollectionViaEvents", _hafTemplateCollectionViaEvents);
			toReturn.Add("LookupCollectionViaEvents", _lookupCollectionViaEvents);
			toReturn.Add("LookupCollectionViaEvents____", _lookupCollectionViaEvents____);
			toReturn.Add("LookupCollectionViaEvents___", _lookupCollectionViaEvents___);
			toReturn.Add("LookupCollectionViaEvents__", _lookupCollectionViaEvents__);
			toReturn.Add("LookupCollectionViaEvents_", _lookupCollectionViaEvents_);
			toReturn.Add("NotesDetailsCollectionViaEvents", _notesDetailsCollectionViaEvents);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents_", _organizationRoleUserCollectionViaEvents_);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents____", _organizationRoleUserCollectionViaEvents____);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents__", _organizationRoleUserCollectionViaEvents__);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents", _organizationRoleUserCollectionViaEvents);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents___", _organizationRoleUserCollectionViaEvents___);
			toReturn.Add("ScheduleMethodCollectionViaEvents", _scheduleMethodCollectionViaEvents);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_eventTypeCollectionViaEvents!=null)
			{
				_eventTypeCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaEvents!=null)
			{
				_hafTemplateCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents!=null)
			{
				_lookupCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents____!=null)
			{
				_lookupCollectionViaEvents____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents___!=null)
			{
				_lookupCollectionViaEvents___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents__!=null)
			{
				_lookupCollectionViaEvents__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents_!=null)
			{
				_lookupCollectionViaEvents_.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaEvents!=null)
			{
				_notesDetailsCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents_!=null)
			{
				_organizationRoleUserCollectionViaEvents_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents____!=null)
			{
				_organizationRoleUserCollectionViaEvents____.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents__!=null)
			{
				_organizationRoleUserCollectionViaEvents__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents!=null)
			{
				_organizationRoleUserCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents___!=null)
			{
				_organizationRoleUserCollectionViaEvents___.ActiveContext = base.ActiveContext;
			}
			if(_scheduleMethodCollectionViaEvents!=null)
			{
				_scheduleMethodCollectionViaEvents.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_events = null;
			_eventTypeCollectionViaEvents = null;
			_hafTemplateCollectionViaEvents = null;
			_lookupCollectionViaEvents = null;
			_lookupCollectionViaEvents____ = null;
			_lookupCollectionViaEvents___ = null;
			_lookupCollectionViaEvents__ = null;
			_lookupCollectionViaEvents_ = null;
			_notesDetailsCollectionViaEvents = null;
			_organizationRoleUserCollectionViaEvents_ = null;
			_organizationRoleUserCollectionViaEvents____ = null;
			_organizationRoleUserCollectionViaEvents__ = null;
			_organizationRoleUserCollectionViaEvents = null;
			_organizationRoleUserCollectionViaEvents___ = null;
			_scheduleMethodCollectionViaEvents = null;


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

			_fieldsCustomProperties.Add("CommunicationModeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CommunicationModeEntity</param>
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
		public  static CommunicationModeRelations Relations
		{
			get	{ return new CommunicationModeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTypeCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<EventTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.EventTypeEntity, 0, null, null, GetRelationsForField("EventTypeCollectionViaEvents"), null, "EventTypeCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaEvents"), null, "HafTemplateCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents"), null, "LookupCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents____
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents____"), null, "LookupCollectionViaEvents____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents___
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents___"), null, "LookupCollectionViaEvents___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents__
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents__"), null, "LookupCollectionViaEvents__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents_
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents_"), null, "LookupCollectionViaEvents_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaEvents"), null, "NotesDetailsCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents_
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents_"), null, "OrganizationRoleUserCollectionViaEvents_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents____
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents____"), null, "OrganizationRoleUserCollectionViaEvents____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents__
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents__"), null, "OrganizationRoleUserCollectionViaEvents__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents"), null, "OrganizationRoleUserCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents___
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents___"), null, "OrganizationRoleUserCollectionViaEvents___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScheduleMethod' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScheduleMethodCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = CommunicationModeEntity.Relations.EventsEntityUsingCommunicationModeId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<ScheduleMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleMethodEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CommunicationModeEntity, (int)Falcon.Data.EntityType.ScheduleMethodEntity, 0, null, null, GetRelationsForField("ScheduleMethodCollectionViaEvents"), null, "ScheduleMethodCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CommunicationModeEntity.CustomProperties;}
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
			get { return CommunicationModeEntity.FieldsCustomProperties;}
		}

		/// <summary> The CommunicationModeId property of the Entity CommunicationMode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCommunicationMode"."CommunicationModeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CommunicationModeId
		{
			get { return (System.Int64)GetValue((int)CommunicationModeFieldIndex.CommunicationModeId, true); }
			set	{ SetValue((int)CommunicationModeFieldIndex.CommunicationModeId, value); }
		}

		/// <summary> The Name property of the Entity CommunicationMode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCommunicationMode"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CommunicationModeFieldIndex.Name, true); }
			set	{ SetValue((int)CommunicationModeFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity CommunicationMode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCommunicationMode"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CommunicationModeFieldIndex.Description, true); }
			set	{ SetValue((int)CommunicationModeFieldIndex.Description, value); }
		}

		/// <summary> The IsActive property of the Entity CommunicationMode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCommunicationMode"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CommunicationModeFieldIndex.IsActive, true); }
			set	{ SetValue((int)CommunicationModeFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity CommunicationMode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCommunicationMode"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CommunicationModeFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CommunicationModeFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity CommunicationMode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCommunicationMode"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)CommunicationModeFieldIndex.DateModified, true); }
			set	{ SetValue((int)CommunicationModeFieldIndex.DateModified, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> Events
		{
			get
			{
				if(_events==null)
				{
					_events = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_events.SetContainingEntityInfo(this, "CommunicationMode");
				}
				return _events;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTypeEntity))]
		public virtual EntityCollection<EventTypeEntity> EventTypeCollectionViaEvents
		{
			get
			{
				if(_eventTypeCollectionViaEvents==null)
				{
					_eventTypeCollectionViaEvents = new EntityCollection<EventTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTypeEntityFactory)));
					_eventTypeCollectionViaEvents.IsReadOnly=true;
				}
				return _eventTypeCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaEvents
		{
			get
			{
				if(_hafTemplateCollectionViaEvents==null)
				{
					_hafTemplateCollectionViaEvents = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaEvents.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents
		{
			get
			{
				if(_lookupCollectionViaEvents==null)
				{
					_lookupCollectionViaEvents = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents____
		{
			get
			{
				if(_lookupCollectionViaEvents____==null)
				{
					_lookupCollectionViaEvents____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents____.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents___
		{
			get
			{
				if(_lookupCollectionViaEvents___==null)
				{
					_lookupCollectionViaEvents___ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents___.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents__
		{
			get
			{
				if(_lookupCollectionViaEvents__==null)
				{
					_lookupCollectionViaEvents__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents__.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents_
		{
			get
			{
				if(_lookupCollectionViaEvents_==null)
				{
					_lookupCollectionViaEvents_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents_.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotesDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotesDetailsEntity))]
		public virtual EntityCollection<NotesDetailsEntity> NotesDetailsCollectionViaEvents
		{
			get
			{
				if(_notesDetailsCollectionViaEvents==null)
				{
					_notesDetailsCollectionViaEvents = new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory)));
					_notesDetailsCollectionViaEvents.IsReadOnly=true;
				}
				return _notesDetailsCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents_==null)
				{
					_organizationRoleUserCollectionViaEvents_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents____
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents____==null)
				{
					_organizationRoleUserCollectionViaEvents____ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents____.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents__
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents__==null)
				{
					_organizationRoleUserCollectionViaEvents__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents==null)
				{
					_organizationRoleUserCollectionViaEvents = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents___
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents___==null)
				{
					_organizationRoleUserCollectionViaEvents___ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents___.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ScheduleMethodEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ScheduleMethodEntity))]
		public virtual EntityCollection<ScheduleMethodEntity> ScheduleMethodCollectionViaEvents
		{
			get
			{
				if(_scheduleMethodCollectionViaEvents==null)
				{
					_scheduleMethodCollectionViaEvents = new EntityCollection<ScheduleMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleMethodEntityFactory)));
					_scheduleMethodCollectionViaEvents.IsReadOnly=true;
				}
				return _scheduleMethodCollectionViaEvents;
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
			get { return (int)Falcon.Data.EntityType.CommunicationModeEntity; }
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
