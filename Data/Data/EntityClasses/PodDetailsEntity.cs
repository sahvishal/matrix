///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:45
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
	/// Entity class which represents the entity 'PodDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PodDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventNoteEntity> _eventNote;
		private EntityCollection<EventPodEntity> _eventPod;
		private EntityCollection<EventStaffAssignmentEntity> _eventStaffAssignment;
		private EntityCollection<PhysicianPodEntity> _physicianPod;
		private EntityCollection<PodDefaultTeamEntity> _podDefaultTeam;
		private EntityCollection<PodInventoryItemEntity> _podInventoryItem;
		private EntityCollection<PodPackageEntity> _podPackage;
		private EntityCollection<PodRoomEntity> _podRoom;
		private EntityCollection<PodTerritoryEntity> _podTerritory;
		private EntityCollection<PodTestEntity> _podTest;
		private EntityCollection<SalesRepPodAssigmentsEntity> _salesRepPodAssigments;
		private EntityCollection<AccountEntity> _accountCollectionViaEventNote;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventPod;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventStaffAssignment;
		private EntityCollection<ItemEntity> _itemCollectionViaPodInventoryItem;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventStaffAssignment__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaSalesRepPodAssigments;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPodDefaultTeam;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventStaffAssignment_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventNote;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventNote_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventStaffAssignment;
		private EntityCollection<PackageEntity> _packageCollectionViaPodPackage;
		private EntityCollection<PhysicianProfileEntity> _physicianProfileCollectionViaPhysicianPod;
		private EntityCollection<StaffEventRoleEntity> _staffEventRoleCollectionViaPodDefaultTeam;
		private EntityCollection<StaffEventRoleEntity> _staffEventRoleCollectionViaEventStaffAssignment;
		private EntityCollection<TerritoryEntity> _territoryCollectionViaPodTerritory;
		private EntityCollection<TerritoryEntity> _territoryCollectionViaEventPod;
		private EntityCollection<TestEntity> _testCollectionViaPodTest;
		private OrganizationEntity _organization;
		private VanDetailsEntity _vanDetails;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
			/// <summary>Member name VanDetails</summary>
			public static readonly string VanDetails = "VanDetails";
			/// <summary>Member name EventNote</summary>
			public static readonly string EventNote = "EventNote";
			/// <summary>Member name EventPod</summary>
			public static readonly string EventPod = "EventPod";
			/// <summary>Member name EventStaffAssignment</summary>
			public static readonly string EventStaffAssignment = "EventStaffAssignment";
			/// <summary>Member name PhysicianPod</summary>
			public static readonly string PhysicianPod = "PhysicianPod";
			/// <summary>Member name PodDefaultTeam</summary>
			public static readonly string PodDefaultTeam = "PodDefaultTeam";
			/// <summary>Member name PodInventoryItem</summary>
			public static readonly string PodInventoryItem = "PodInventoryItem";
			/// <summary>Member name PodPackage</summary>
			public static readonly string PodPackage = "PodPackage";
			/// <summary>Member name PodRoom</summary>
			public static readonly string PodRoom = "PodRoom";
			/// <summary>Member name PodTerritory</summary>
			public static readonly string PodTerritory = "PodTerritory";
			/// <summary>Member name PodTest</summary>
			public static readonly string PodTest = "PodTest";
			/// <summary>Member name SalesRepPodAssigments</summary>
			public static readonly string SalesRepPodAssigments = "SalesRepPodAssigments";
			/// <summary>Member name AccountCollectionViaEventNote</summary>
			public static readonly string AccountCollectionViaEventNote = "AccountCollectionViaEventNote";
			/// <summary>Member name EventsCollectionViaEventPod</summary>
			public static readonly string EventsCollectionViaEventPod = "EventsCollectionViaEventPod";
			/// <summary>Member name EventsCollectionViaEventStaffAssignment</summary>
			public static readonly string EventsCollectionViaEventStaffAssignment = "EventsCollectionViaEventStaffAssignment";
			/// <summary>Member name ItemCollectionViaPodInventoryItem</summary>
			public static readonly string ItemCollectionViaPodInventoryItem = "ItemCollectionViaPodInventoryItem";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventStaffAssignment__</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventStaffAssignment__ = "OrganizationRoleUserCollectionViaEventStaffAssignment__";
			/// <summary>Member name OrganizationRoleUserCollectionViaSalesRepPodAssigments</summary>
			public static readonly string OrganizationRoleUserCollectionViaSalesRepPodAssigments = "OrganizationRoleUserCollectionViaSalesRepPodAssigments";
			/// <summary>Member name OrganizationRoleUserCollectionViaPodDefaultTeam</summary>
			public static readonly string OrganizationRoleUserCollectionViaPodDefaultTeam = "OrganizationRoleUserCollectionViaPodDefaultTeam";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventStaffAssignment_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventStaffAssignment_ = "OrganizationRoleUserCollectionViaEventStaffAssignment_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventNote</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventNote = "OrganizationRoleUserCollectionViaEventNote";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventNote_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventNote_ = "OrganizationRoleUserCollectionViaEventNote_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventStaffAssignment</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventStaffAssignment = "OrganizationRoleUserCollectionViaEventStaffAssignment";
			/// <summary>Member name PackageCollectionViaPodPackage</summary>
			public static readonly string PackageCollectionViaPodPackage = "PackageCollectionViaPodPackage";
			/// <summary>Member name PhysicianProfileCollectionViaPhysicianPod</summary>
			public static readonly string PhysicianProfileCollectionViaPhysicianPod = "PhysicianProfileCollectionViaPhysicianPod";
			/// <summary>Member name StaffEventRoleCollectionViaPodDefaultTeam</summary>
			public static readonly string StaffEventRoleCollectionViaPodDefaultTeam = "StaffEventRoleCollectionViaPodDefaultTeam";
			/// <summary>Member name StaffEventRoleCollectionViaEventStaffAssignment</summary>
			public static readonly string StaffEventRoleCollectionViaEventStaffAssignment = "StaffEventRoleCollectionViaEventStaffAssignment";
			/// <summary>Member name TerritoryCollectionViaPodTerritory</summary>
			public static readonly string TerritoryCollectionViaPodTerritory = "TerritoryCollectionViaPodTerritory";
			/// <summary>Member name TerritoryCollectionViaEventPod</summary>
			public static readonly string TerritoryCollectionViaEventPod = "TerritoryCollectionViaEventPod";
			/// <summary>Member name TestCollectionViaPodTest</summary>
			public static readonly string TestCollectionViaPodTest = "TestCollectionViaPodTest";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PodDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PodDetailsEntity():base("PodDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PodDetailsEntity(IEntityFields2 fields):base("PodDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PodDetailsEntity</param>
		public PodDetailsEntity(IValidator validator):base("PodDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="podId">PK value for PodDetails which data should be fetched into this PodDetails object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PodDetailsEntity(System.Int64 podId):base("PodDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PodId = podId;
		}

		/// <summary> CTor</summary>
		/// <param name="podId">PK value for PodDetails which data should be fetched into this PodDetails object</param>
		/// <param name="validator">The custom validator object for this PodDetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PodDetailsEntity(System.Int64 podId, IValidator validator):base("PodDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PodId = podId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PodDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventNote = (EntityCollection<EventNoteEntity>)info.GetValue("_eventNote", typeof(EntityCollection<EventNoteEntity>));
				_eventPod = (EntityCollection<EventPodEntity>)info.GetValue("_eventPod", typeof(EntityCollection<EventPodEntity>));
				_eventStaffAssignment = (EntityCollection<EventStaffAssignmentEntity>)info.GetValue("_eventStaffAssignment", typeof(EntityCollection<EventStaffAssignmentEntity>));
				_physicianPod = (EntityCollection<PhysicianPodEntity>)info.GetValue("_physicianPod", typeof(EntityCollection<PhysicianPodEntity>));
				_podDefaultTeam = (EntityCollection<PodDefaultTeamEntity>)info.GetValue("_podDefaultTeam", typeof(EntityCollection<PodDefaultTeamEntity>));
				_podInventoryItem = (EntityCollection<PodInventoryItemEntity>)info.GetValue("_podInventoryItem", typeof(EntityCollection<PodInventoryItemEntity>));
				_podPackage = (EntityCollection<PodPackageEntity>)info.GetValue("_podPackage", typeof(EntityCollection<PodPackageEntity>));
				_podRoom = (EntityCollection<PodRoomEntity>)info.GetValue("_podRoom", typeof(EntityCollection<PodRoomEntity>));
				_podTerritory = (EntityCollection<PodTerritoryEntity>)info.GetValue("_podTerritory", typeof(EntityCollection<PodTerritoryEntity>));
				_podTest = (EntityCollection<PodTestEntity>)info.GetValue("_podTest", typeof(EntityCollection<PodTestEntity>));
				_salesRepPodAssigments = (EntityCollection<SalesRepPodAssigmentsEntity>)info.GetValue("_salesRepPodAssigments", typeof(EntityCollection<SalesRepPodAssigmentsEntity>));
				_accountCollectionViaEventNote = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaEventNote", typeof(EntityCollection<AccountEntity>));
				_eventsCollectionViaEventPod = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventPod", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventStaffAssignment = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventStaffAssignment", typeof(EntityCollection<EventsEntity>));
				_itemCollectionViaPodInventoryItem = (EntityCollection<ItemEntity>)info.GetValue("_itemCollectionViaPodInventoryItem", typeof(EntityCollection<ItemEntity>));
				_organizationRoleUserCollectionViaEventStaffAssignment__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventStaffAssignment__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaSalesRepPodAssigments = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaSalesRepPodAssigments", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPodDefaultTeam = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPodDefaultTeam", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventStaffAssignment_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventStaffAssignment_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventNote = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventNote", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventNote_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventNote_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventStaffAssignment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventStaffAssignment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_packageCollectionViaPodPackage = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaPodPackage", typeof(EntityCollection<PackageEntity>));
				_physicianProfileCollectionViaPhysicianPod = (EntityCollection<PhysicianProfileEntity>)info.GetValue("_physicianProfileCollectionViaPhysicianPod", typeof(EntityCollection<PhysicianProfileEntity>));
				_staffEventRoleCollectionViaPodDefaultTeam = (EntityCollection<StaffEventRoleEntity>)info.GetValue("_staffEventRoleCollectionViaPodDefaultTeam", typeof(EntityCollection<StaffEventRoleEntity>));
				_staffEventRoleCollectionViaEventStaffAssignment = (EntityCollection<StaffEventRoleEntity>)info.GetValue("_staffEventRoleCollectionViaEventStaffAssignment", typeof(EntityCollection<StaffEventRoleEntity>));
				_territoryCollectionViaPodTerritory = (EntityCollection<TerritoryEntity>)info.GetValue("_territoryCollectionViaPodTerritory", typeof(EntityCollection<TerritoryEntity>));
				_territoryCollectionViaEventPod = (EntityCollection<TerritoryEntity>)info.GetValue("_territoryCollectionViaEventPod", typeof(EntityCollection<TerritoryEntity>));
				_testCollectionViaPodTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaPodTest", typeof(EntityCollection<TestEntity>));
				_organization = (OrganizationEntity)info.GetValue("_organization", typeof(OrganizationEntity));
				if(_organization!=null)
				{
					_organization.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_vanDetails = (VanDetailsEntity)info.GetValue("_vanDetails", typeof(VanDetailsEntity));
				if(_vanDetails!=null)
				{
					_vanDetails.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PodDetailsFieldIndex)fieldIndex)
			{
				case PodDetailsFieldIndex.VanId:
					DesetupSyncVanDetails(true, false);
					break;
				case PodDetailsFieldIndex.OrganizationId:
					DesetupSyncOrganization(true, false);
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
				case "Organization":
					this.Organization = (OrganizationEntity)entity;
					break;
				case "VanDetails":
					this.VanDetails = (VanDetailsEntity)entity;
					break;
				case "EventNote":
					this.EventNote.Add((EventNoteEntity)entity);
					break;
				case "EventPod":
					this.EventPod.Add((EventPodEntity)entity);
					break;
				case "EventStaffAssignment":
					this.EventStaffAssignment.Add((EventStaffAssignmentEntity)entity);
					break;
				case "PhysicianPod":
					this.PhysicianPod.Add((PhysicianPodEntity)entity);
					break;
				case "PodDefaultTeam":
					this.PodDefaultTeam.Add((PodDefaultTeamEntity)entity);
					break;
				case "PodInventoryItem":
					this.PodInventoryItem.Add((PodInventoryItemEntity)entity);
					break;
				case "PodPackage":
					this.PodPackage.Add((PodPackageEntity)entity);
					break;
				case "PodRoom":
					this.PodRoom.Add((PodRoomEntity)entity);
					break;
				case "PodTerritory":
					this.PodTerritory.Add((PodTerritoryEntity)entity);
					break;
				case "PodTest":
					this.PodTest.Add((PodTestEntity)entity);
					break;
				case "SalesRepPodAssigments":
					this.SalesRepPodAssigments.Add((SalesRepPodAssigmentsEntity)entity);
					break;
				case "AccountCollectionViaEventNote":
					this.AccountCollectionViaEventNote.IsReadOnly = false;
					this.AccountCollectionViaEventNote.Add((AccountEntity)entity);
					this.AccountCollectionViaEventNote.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventPod":
					this.EventsCollectionViaEventPod.IsReadOnly = false;
					this.EventsCollectionViaEventPod.Add((EventsEntity)entity);
					this.EventsCollectionViaEventPod.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventStaffAssignment":
					this.EventsCollectionViaEventStaffAssignment.IsReadOnly = false;
					this.EventsCollectionViaEventStaffAssignment.Add((EventsEntity)entity);
					this.EventsCollectionViaEventStaffAssignment.IsReadOnly = true;
					break;
				case "ItemCollectionViaPodInventoryItem":
					this.ItemCollectionViaPodInventoryItem.IsReadOnly = false;
					this.ItemCollectionViaPodInventoryItem.Add((ItemEntity)entity);
					this.ItemCollectionViaPodInventoryItem.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment__":
					this.OrganizationRoleUserCollectionViaEventStaffAssignment__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventStaffAssignment__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventStaffAssignment__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaSalesRepPodAssigments":
					this.OrganizationRoleUserCollectionViaSalesRepPodAssigments.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaSalesRepPodAssigments.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaSalesRepPodAssigments.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPodDefaultTeam":
					this.OrganizationRoleUserCollectionViaPodDefaultTeam.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPodDefaultTeam.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPodDefaultTeam.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment_":
					this.OrganizationRoleUserCollectionViaEventStaffAssignment_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventStaffAssignment_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventStaffAssignment_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventNote":
					this.OrganizationRoleUserCollectionViaEventNote.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventNote.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventNote.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventNote_":
					this.OrganizationRoleUserCollectionViaEventNote_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventNote_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventNote_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment":
					this.OrganizationRoleUserCollectionViaEventStaffAssignment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventStaffAssignment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventStaffAssignment.IsReadOnly = true;
					break;
				case "PackageCollectionViaPodPackage":
					this.PackageCollectionViaPodPackage.IsReadOnly = false;
					this.PackageCollectionViaPodPackage.Add((PackageEntity)entity);
					this.PackageCollectionViaPodPackage.IsReadOnly = true;
					break;
				case "PhysicianProfileCollectionViaPhysicianPod":
					this.PhysicianProfileCollectionViaPhysicianPod.IsReadOnly = false;
					this.PhysicianProfileCollectionViaPhysicianPod.Add((PhysicianProfileEntity)entity);
					this.PhysicianProfileCollectionViaPhysicianPod.IsReadOnly = true;
					break;
				case "StaffEventRoleCollectionViaPodDefaultTeam":
					this.StaffEventRoleCollectionViaPodDefaultTeam.IsReadOnly = false;
					this.StaffEventRoleCollectionViaPodDefaultTeam.Add((StaffEventRoleEntity)entity);
					this.StaffEventRoleCollectionViaPodDefaultTeam.IsReadOnly = true;
					break;
				case "StaffEventRoleCollectionViaEventStaffAssignment":
					this.StaffEventRoleCollectionViaEventStaffAssignment.IsReadOnly = false;
					this.StaffEventRoleCollectionViaEventStaffAssignment.Add((StaffEventRoleEntity)entity);
					this.StaffEventRoleCollectionViaEventStaffAssignment.IsReadOnly = true;
					break;
				case "TerritoryCollectionViaPodTerritory":
					this.TerritoryCollectionViaPodTerritory.IsReadOnly = false;
					this.TerritoryCollectionViaPodTerritory.Add((TerritoryEntity)entity);
					this.TerritoryCollectionViaPodTerritory.IsReadOnly = true;
					break;
				case "TerritoryCollectionViaEventPod":
					this.TerritoryCollectionViaEventPod.IsReadOnly = false;
					this.TerritoryCollectionViaEventPod.Add((TerritoryEntity)entity);
					this.TerritoryCollectionViaEventPod.IsReadOnly = true;
					break;
				case "TestCollectionViaPodTest":
					this.TestCollectionViaPodTest.IsReadOnly = false;
					this.TestCollectionViaPodTest.Add((TestEntity)entity);
					this.TestCollectionViaPodTest.IsReadOnly = true;
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
			return PodDetailsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Organization":
					toReturn.Add(PodDetailsEntity.Relations.OrganizationEntityUsingOrganizationId);
					break;
				case "VanDetails":
					toReturn.Add(PodDetailsEntity.Relations.VanDetailsEntityUsingVanId);
					break;
				case "EventNote":
					toReturn.Add(PodDetailsEntity.Relations.EventNoteEntityUsingPodId);
					break;
				case "EventPod":
					toReturn.Add(PodDetailsEntity.Relations.EventPodEntityUsingPodId);
					break;
				case "EventStaffAssignment":
					toReturn.Add(PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId);
					break;
				case "PhysicianPod":
					toReturn.Add(PodDetailsEntity.Relations.PhysicianPodEntityUsingPodId);
					break;
				case "PodDefaultTeam":
					toReturn.Add(PodDetailsEntity.Relations.PodDefaultTeamEntityUsingPodId);
					break;
				case "PodInventoryItem":
					toReturn.Add(PodDetailsEntity.Relations.PodInventoryItemEntityUsingPodId);
					break;
				case "PodPackage":
					toReturn.Add(PodDetailsEntity.Relations.PodPackageEntityUsingPodId);
					break;
				case "PodRoom":
					toReturn.Add(PodDetailsEntity.Relations.PodRoomEntityUsingPodId);
					break;
				case "PodTerritory":
					toReturn.Add(PodDetailsEntity.Relations.PodTerritoryEntityUsingPodId);
					break;
				case "PodTest":
					toReturn.Add(PodDetailsEntity.Relations.PodTestEntityUsingPodId);
					break;
				case "SalesRepPodAssigments":
					toReturn.Add(PodDetailsEntity.Relations.SalesRepPodAssigmentsEntityUsingPodId);
					break;
				case "AccountCollectionViaEventNote":
					toReturn.Add(PodDetailsEntity.Relations.EventNoteEntityUsingPodId, "PodDetailsEntity__", "EventNote_", JoinHint.None);
					toReturn.Add(EventNoteEntity.Relations.AccountEntityUsingHealthPlanId, "EventNote_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventPod":
					toReturn.Add(PodDetailsEntity.Relations.EventPodEntityUsingPodId, "PodDetailsEntity__", "EventPod_", JoinHint.None);
					toReturn.Add(EventPodEntity.Relations.EventsEntityUsingEventId, "EventPod_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventStaffAssignment":
					toReturn.Add(PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId, "PodDetailsEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.EventsEntityUsingEventId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "ItemCollectionViaPodInventoryItem":
					toReturn.Add(PodDetailsEntity.Relations.PodInventoryItemEntityUsingPodId, "PodDetailsEntity__", "PodInventoryItem_", JoinHint.None);
					toReturn.Add(PodInventoryItemEntity.Relations.ItemEntityUsingItemId, "PodInventoryItem_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment__":
					toReturn.Add(PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId, "PodDetailsEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.OrganizationRoleUserEntityUsingScheduledByOrgRoleUserId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaSalesRepPodAssigments":
					toReturn.Add(PodDetailsEntity.Relations.SalesRepPodAssigmentsEntityUsingPodId, "PodDetailsEntity__", "SalesRepPodAssigments_", JoinHint.None);
					toReturn.Add(SalesRepPodAssigmentsEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId, "SalesRepPodAssigments_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPodDefaultTeam":
					toReturn.Add(PodDetailsEntity.Relations.PodDefaultTeamEntityUsingPodId, "PodDetailsEntity__", "PodDefaultTeam_", JoinHint.None);
					toReturn.Add(PodDefaultTeamEntity.Relations.OrganizationRoleUserEntityUsingOrgnizationRoleUserId, "PodDefaultTeam_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment_":
					toReturn.Add(PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId, "PodDetailsEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.OrganizationRoleUserEntityUsingActualStaffOrgRoleUserId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventNote":
					toReturn.Add(PodDetailsEntity.Relations.EventNoteEntityUsingPodId, "PodDetailsEntity__", "EventNote_", JoinHint.None);
					toReturn.Add(EventNoteEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventNote_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventNote_":
					toReturn.Add(PodDetailsEntity.Relations.EventNoteEntityUsingPodId, "PodDetailsEntity__", "EventNote_", JoinHint.None);
					toReturn.Add(EventNoteEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "EventNote_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment":
					toReturn.Add(PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId, "PodDetailsEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.OrganizationRoleUserEntityUsingScheduledStaffOrgRoleUserId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaPodPackage":
					toReturn.Add(PodDetailsEntity.Relations.PodPackageEntityUsingPodId, "PodDetailsEntity__", "PodPackage_", JoinHint.None);
					toReturn.Add(PodPackageEntity.Relations.PackageEntityUsingPackageId, "PodPackage_", string.Empty, JoinHint.None);
					break;
				case "PhysicianProfileCollectionViaPhysicianPod":
					toReturn.Add(PodDetailsEntity.Relations.PhysicianPodEntityUsingPodId, "PodDetailsEntity__", "PhysicianPod_", JoinHint.None);
					toReturn.Add(PhysicianPodEntity.Relations.PhysicianProfileEntityUsingPhysicianId, "PhysicianPod_", string.Empty, JoinHint.None);
					break;
				case "StaffEventRoleCollectionViaPodDefaultTeam":
					toReturn.Add(PodDetailsEntity.Relations.PodDefaultTeamEntityUsingPodId, "PodDetailsEntity__", "PodDefaultTeam_", JoinHint.None);
					toReturn.Add(PodDefaultTeamEntity.Relations.StaffEventRoleEntityUsingEventRoleId, "PodDefaultTeam_", string.Empty, JoinHint.None);
					break;
				case "StaffEventRoleCollectionViaEventStaffAssignment":
					toReturn.Add(PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId, "PodDetailsEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.StaffEventRoleEntityUsingStaffEventRoleId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "TerritoryCollectionViaPodTerritory":
					toReturn.Add(PodDetailsEntity.Relations.PodTerritoryEntityUsingPodId, "PodDetailsEntity__", "PodTerritory_", JoinHint.None);
					toReturn.Add(PodTerritoryEntity.Relations.TerritoryEntityUsingTerritoryId, "PodTerritory_", string.Empty, JoinHint.None);
					break;
				case "TerritoryCollectionViaEventPod":
					toReturn.Add(PodDetailsEntity.Relations.EventPodEntityUsingPodId, "PodDetailsEntity__", "EventPod_", JoinHint.None);
					toReturn.Add(EventPodEntity.Relations.TerritoryEntityUsingTerritoryId, "EventPod_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaPodTest":
					toReturn.Add(PodDetailsEntity.Relations.PodTestEntityUsingPodId, "PodDetailsEntity__", "PodTest_", JoinHint.None);
					toReturn.Add(PodTestEntity.Relations.TestEntityUsingTestId, "PodTest_", string.Empty, JoinHint.None);
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
				case "Organization":
					SetupSyncOrganization(relatedEntity);
					break;
				case "VanDetails":
					SetupSyncVanDetails(relatedEntity);
					break;
				case "EventNote":
					this.EventNote.Add((EventNoteEntity)relatedEntity);
					break;
				case "EventPod":
					this.EventPod.Add((EventPodEntity)relatedEntity);
					break;
				case "EventStaffAssignment":
					this.EventStaffAssignment.Add((EventStaffAssignmentEntity)relatedEntity);
					break;
				case "PhysicianPod":
					this.PhysicianPod.Add((PhysicianPodEntity)relatedEntity);
					break;
				case "PodDefaultTeam":
					this.PodDefaultTeam.Add((PodDefaultTeamEntity)relatedEntity);
					break;
				case "PodInventoryItem":
					this.PodInventoryItem.Add((PodInventoryItemEntity)relatedEntity);
					break;
				case "PodPackage":
					this.PodPackage.Add((PodPackageEntity)relatedEntity);
					break;
				case "PodRoom":
					this.PodRoom.Add((PodRoomEntity)relatedEntity);
					break;
				case "PodTerritory":
					this.PodTerritory.Add((PodTerritoryEntity)relatedEntity);
					break;
				case "PodTest":
					this.PodTest.Add((PodTestEntity)relatedEntity);
					break;
				case "SalesRepPodAssigments":
					this.SalesRepPodAssigments.Add((SalesRepPodAssigmentsEntity)relatedEntity);
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
				case "Organization":
					DesetupSyncOrganization(false, true);
					break;
				case "VanDetails":
					DesetupSyncVanDetails(false, true);
					break;
				case "EventNote":
					base.PerformRelatedEntityRemoval(this.EventNote, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventPod":
					base.PerformRelatedEntityRemoval(this.EventPod, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventStaffAssignment":
					base.PerformRelatedEntityRemoval(this.EventStaffAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianPod":
					base.PerformRelatedEntityRemoval(this.PhysicianPod, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodDefaultTeam":
					base.PerformRelatedEntityRemoval(this.PodDefaultTeam, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodInventoryItem":
					base.PerformRelatedEntityRemoval(this.PodInventoryItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodPackage":
					base.PerformRelatedEntityRemoval(this.PodPackage, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodRoom":
					base.PerformRelatedEntityRemoval(this.PodRoom, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodTerritory":
					base.PerformRelatedEntityRemoval(this.PodTerritory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodTest":
					base.PerformRelatedEntityRemoval(this.PodTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SalesRepPodAssigments":
					base.PerformRelatedEntityRemoval(this.SalesRepPodAssigments, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organization!=null)
			{
				toReturn.Add(_organization);
			}
			if(_vanDetails!=null)
			{
				toReturn.Add(_vanDetails);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventNote);
			toReturn.Add(this.EventPod);
			toReturn.Add(this.EventStaffAssignment);
			toReturn.Add(this.PhysicianPod);
			toReturn.Add(this.PodDefaultTeam);
			toReturn.Add(this.PodInventoryItem);
			toReturn.Add(this.PodPackage);
			toReturn.Add(this.PodRoom);
			toReturn.Add(this.PodTerritory);
			toReturn.Add(this.PodTest);
			toReturn.Add(this.SalesRepPodAssigments);

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
				info.AddValue("_eventNote", ((_eventNote!=null) && (_eventNote.Count>0) && !this.MarkedForDeletion)?_eventNote:null);
				info.AddValue("_eventPod", ((_eventPod!=null) && (_eventPod.Count>0) && !this.MarkedForDeletion)?_eventPod:null);
				info.AddValue("_eventStaffAssignment", ((_eventStaffAssignment!=null) && (_eventStaffAssignment.Count>0) && !this.MarkedForDeletion)?_eventStaffAssignment:null);
				info.AddValue("_physicianPod", ((_physicianPod!=null) && (_physicianPod.Count>0) && !this.MarkedForDeletion)?_physicianPod:null);
				info.AddValue("_podDefaultTeam", ((_podDefaultTeam!=null) && (_podDefaultTeam.Count>0) && !this.MarkedForDeletion)?_podDefaultTeam:null);
				info.AddValue("_podInventoryItem", ((_podInventoryItem!=null) && (_podInventoryItem.Count>0) && !this.MarkedForDeletion)?_podInventoryItem:null);
				info.AddValue("_podPackage", ((_podPackage!=null) && (_podPackage.Count>0) && !this.MarkedForDeletion)?_podPackage:null);
				info.AddValue("_podRoom", ((_podRoom!=null) && (_podRoom.Count>0) && !this.MarkedForDeletion)?_podRoom:null);
				info.AddValue("_podTerritory", ((_podTerritory!=null) && (_podTerritory.Count>0) && !this.MarkedForDeletion)?_podTerritory:null);
				info.AddValue("_podTest", ((_podTest!=null) && (_podTest.Count>0) && !this.MarkedForDeletion)?_podTest:null);
				info.AddValue("_salesRepPodAssigments", ((_salesRepPodAssigments!=null) && (_salesRepPodAssigments.Count>0) && !this.MarkedForDeletion)?_salesRepPodAssigments:null);
				info.AddValue("_accountCollectionViaEventNote", ((_accountCollectionViaEventNote!=null) && (_accountCollectionViaEventNote.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaEventNote:null);
				info.AddValue("_eventsCollectionViaEventPod", ((_eventsCollectionViaEventPod!=null) && (_eventsCollectionViaEventPod.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventPod:null);
				info.AddValue("_eventsCollectionViaEventStaffAssignment", ((_eventsCollectionViaEventStaffAssignment!=null) && (_eventsCollectionViaEventStaffAssignment.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventStaffAssignment:null);
				info.AddValue("_itemCollectionViaPodInventoryItem", ((_itemCollectionViaPodInventoryItem!=null) && (_itemCollectionViaPodInventoryItem.Count>0) && !this.MarkedForDeletion)?_itemCollectionViaPodInventoryItem:null);
				info.AddValue("_organizationRoleUserCollectionViaEventStaffAssignment__", ((_organizationRoleUserCollectionViaEventStaffAssignment__!=null) && (_organizationRoleUserCollectionViaEventStaffAssignment__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventStaffAssignment__:null);
				info.AddValue("_organizationRoleUserCollectionViaSalesRepPodAssigments", ((_organizationRoleUserCollectionViaSalesRepPodAssigments!=null) && (_organizationRoleUserCollectionViaSalesRepPodAssigments.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaSalesRepPodAssigments:null);
				info.AddValue("_organizationRoleUserCollectionViaPodDefaultTeam", ((_organizationRoleUserCollectionViaPodDefaultTeam!=null) && (_organizationRoleUserCollectionViaPodDefaultTeam.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPodDefaultTeam:null);
				info.AddValue("_organizationRoleUserCollectionViaEventStaffAssignment_", ((_organizationRoleUserCollectionViaEventStaffAssignment_!=null) && (_organizationRoleUserCollectionViaEventStaffAssignment_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventStaffAssignment_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventNote", ((_organizationRoleUserCollectionViaEventNote!=null) && (_organizationRoleUserCollectionViaEventNote.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventNote:null);
				info.AddValue("_organizationRoleUserCollectionViaEventNote_", ((_organizationRoleUserCollectionViaEventNote_!=null) && (_organizationRoleUserCollectionViaEventNote_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventNote_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventStaffAssignment", ((_organizationRoleUserCollectionViaEventStaffAssignment!=null) && (_organizationRoleUserCollectionViaEventStaffAssignment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventStaffAssignment:null);
				info.AddValue("_packageCollectionViaPodPackage", ((_packageCollectionViaPodPackage!=null) && (_packageCollectionViaPodPackage.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaPodPackage:null);
				info.AddValue("_physicianProfileCollectionViaPhysicianPod", ((_physicianProfileCollectionViaPhysicianPod!=null) && (_physicianProfileCollectionViaPhysicianPod.Count>0) && !this.MarkedForDeletion)?_physicianProfileCollectionViaPhysicianPod:null);
				info.AddValue("_staffEventRoleCollectionViaPodDefaultTeam", ((_staffEventRoleCollectionViaPodDefaultTeam!=null) && (_staffEventRoleCollectionViaPodDefaultTeam.Count>0) && !this.MarkedForDeletion)?_staffEventRoleCollectionViaPodDefaultTeam:null);
				info.AddValue("_staffEventRoleCollectionViaEventStaffAssignment", ((_staffEventRoleCollectionViaEventStaffAssignment!=null) && (_staffEventRoleCollectionViaEventStaffAssignment.Count>0) && !this.MarkedForDeletion)?_staffEventRoleCollectionViaEventStaffAssignment:null);
				info.AddValue("_territoryCollectionViaPodTerritory", ((_territoryCollectionViaPodTerritory!=null) && (_territoryCollectionViaPodTerritory.Count>0) && !this.MarkedForDeletion)?_territoryCollectionViaPodTerritory:null);
				info.AddValue("_territoryCollectionViaEventPod", ((_territoryCollectionViaEventPod!=null) && (_territoryCollectionViaEventPod.Count>0) && !this.MarkedForDeletion)?_territoryCollectionViaEventPod:null);
				info.AddValue("_testCollectionViaPodTest", ((_testCollectionViaPodTest!=null) && (_testCollectionViaPodTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaPodTest:null);
				info.AddValue("_organization", (!this.MarkedForDeletion?_organization:null));
				info.AddValue("_vanDetails", (!this.MarkedForDeletion?_vanDetails:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PodDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PodDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PodDetailsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventNote' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventNote()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventNoteFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPod' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPodFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventStaffAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventStaffAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventStaffAssignmentFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianPod' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianPodFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDefaultTeam' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDefaultTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDefaultTeamFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodInventoryItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodInventoryItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodInventoryItemFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodPackage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodPackageFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodRoom' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodRoom()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodRoomFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodTerritory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodTerritoryFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodTestFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SalesRepPodAssigments' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSalesRepPodAssigments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SalesRepPodAssigmentsFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaEventNote()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaEventNote"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventPod"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventStaffAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventStaffAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Item' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoItemCollectionViaPodInventoryItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ItemCollectionViaPodInventoryItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventStaffAssignment__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventStaffAssignment__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaSalesRepPodAssigments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaSalesRepPodAssigments"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPodDefaultTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPodDefaultTeam"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventStaffAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventStaffAssignment_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventNote()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventNote"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventNote_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventNote_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventStaffAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventStaffAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaPodPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaPodPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfileCollectionViaPhysicianPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianProfileCollectionViaPhysicianPod"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StaffEventRole' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStaffEventRoleCollectionViaPodDefaultTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StaffEventRoleCollectionViaPodDefaultTeam"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StaffEventRole' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStaffEventRoleCollectionViaEventStaffAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StaffEventRoleCollectionViaEventStaffAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Territory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritoryCollectionViaPodTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TerritoryCollectionViaPodTerritory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Territory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritoryCollectionViaEventPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TerritoryCollectionViaEventPod"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaPodTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaPodTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId, "PodDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Organization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'VanDetails' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoVanDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(VanDetailsFields.VanId, null, ComparisonOperator.Equal, this.VanId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PodDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventNote);
			collectionsQueue.Enqueue(this._eventPod);
			collectionsQueue.Enqueue(this._eventStaffAssignment);
			collectionsQueue.Enqueue(this._physicianPod);
			collectionsQueue.Enqueue(this._podDefaultTeam);
			collectionsQueue.Enqueue(this._podInventoryItem);
			collectionsQueue.Enqueue(this._podPackage);
			collectionsQueue.Enqueue(this._podRoom);
			collectionsQueue.Enqueue(this._podTerritory);
			collectionsQueue.Enqueue(this._podTest);
			collectionsQueue.Enqueue(this._salesRepPodAssigments);
			collectionsQueue.Enqueue(this._accountCollectionViaEventNote);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventPod);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventStaffAssignment);
			collectionsQueue.Enqueue(this._itemCollectionViaPodInventoryItem);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventStaffAssignment__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaSalesRepPodAssigments);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPodDefaultTeam);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventStaffAssignment_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventNote);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventNote_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventStaffAssignment);
			collectionsQueue.Enqueue(this._packageCollectionViaPodPackage);
			collectionsQueue.Enqueue(this._physicianProfileCollectionViaPhysicianPod);
			collectionsQueue.Enqueue(this._staffEventRoleCollectionViaPodDefaultTeam);
			collectionsQueue.Enqueue(this._staffEventRoleCollectionViaEventStaffAssignment);
			collectionsQueue.Enqueue(this._territoryCollectionViaPodTerritory);
			collectionsQueue.Enqueue(this._territoryCollectionViaEventPod);
			collectionsQueue.Enqueue(this._testCollectionViaPodTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventNote = (EntityCollection<EventNoteEntity>) collectionsQueue.Dequeue();
			this._eventPod = (EntityCollection<EventPodEntity>) collectionsQueue.Dequeue();
			this._eventStaffAssignment = (EntityCollection<EventStaffAssignmentEntity>) collectionsQueue.Dequeue();
			this._physicianPod = (EntityCollection<PhysicianPodEntity>) collectionsQueue.Dequeue();
			this._podDefaultTeam = (EntityCollection<PodDefaultTeamEntity>) collectionsQueue.Dequeue();
			this._podInventoryItem = (EntityCollection<PodInventoryItemEntity>) collectionsQueue.Dequeue();
			this._podPackage = (EntityCollection<PodPackageEntity>) collectionsQueue.Dequeue();
			this._podRoom = (EntityCollection<PodRoomEntity>) collectionsQueue.Dequeue();
			this._podTerritory = (EntityCollection<PodTerritoryEntity>) collectionsQueue.Dequeue();
			this._podTest = (EntityCollection<PodTestEntity>) collectionsQueue.Dequeue();
			this._salesRepPodAssigments = (EntityCollection<SalesRepPodAssigmentsEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaEventNote = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventPod = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventStaffAssignment = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._itemCollectionViaPodInventoryItem = (EntityCollection<ItemEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventStaffAssignment__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaSalesRepPodAssigments = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPodDefaultTeam = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventStaffAssignment_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventNote = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventNote_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventStaffAssignment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaPodPackage = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._physicianProfileCollectionViaPhysicianPod = (EntityCollection<PhysicianProfileEntity>) collectionsQueue.Dequeue();
			this._staffEventRoleCollectionViaPodDefaultTeam = (EntityCollection<StaffEventRoleEntity>) collectionsQueue.Dequeue();
			this._staffEventRoleCollectionViaEventStaffAssignment = (EntityCollection<StaffEventRoleEntity>) collectionsQueue.Dequeue();
			this._territoryCollectionViaPodTerritory = (EntityCollection<TerritoryEntity>) collectionsQueue.Dequeue();
			this._territoryCollectionViaEventPod = (EntityCollection<TerritoryEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaPodTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventNote != null)
			{
				return true;
			}
			if (this._eventPod != null)
			{
				return true;
			}
			if (this._eventStaffAssignment != null)
			{
				return true;
			}
			if (this._physicianPod != null)
			{
				return true;
			}
			if (this._podDefaultTeam != null)
			{
				return true;
			}
			if (this._podInventoryItem != null)
			{
				return true;
			}
			if (this._podPackage != null)
			{
				return true;
			}
			if (this._podRoom != null)
			{
				return true;
			}
			if (this._podTerritory != null)
			{
				return true;
			}
			if (this._podTest != null)
			{
				return true;
			}
			if (this._salesRepPodAssigments != null)
			{
				return true;
			}
			if (this._accountCollectionViaEventNote != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventPod != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventStaffAssignment != null)
			{
				return true;
			}
			if (this._itemCollectionViaPodInventoryItem != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventStaffAssignment__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaSalesRepPodAssigments != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPodDefaultTeam != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventStaffAssignment_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventNote != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventNote_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventStaffAssignment != null)
			{
				return true;
			}
			if (this._packageCollectionViaPodPackage != null)
			{
				return true;
			}
			if (this._physicianProfileCollectionViaPhysicianPod != null)
			{
				return true;
			}
			if (this._staffEventRoleCollectionViaPodDefaultTeam != null)
			{
				return true;
			}
			if (this._staffEventRoleCollectionViaEventStaffAssignment != null)
			{
				return true;
			}
			if (this._territoryCollectionViaPodTerritory != null)
			{
				return true;
			}
			if (this._territoryCollectionViaEventPod != null)
			{
				return true;
			}
			if (this._testCollectionViaPodTest != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventNoteEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventStaffAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventStaffAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPodEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDefaultTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDefaultTeamEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodInventoryItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodInventoryItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodPackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SalesRepPodAssigmentsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SalesRepPodAssigmentsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StaffEventRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StaffEventRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Organization", _organization);
			toReturn.Add("VanDetails", _vanDetails);
			toReturn.Add("EventNote", _eventNote);
			toReturn.Add("EventPod", _eventPod);
			toReturn.Add("EventStaffAssignment", _eventStaffAssignment);
			toReturn.Add("PhysicianPod", _physicianPod);
			toReturn.Add("PodDefaultTeam", _podDefaultTeam);
			toReturn.Add("PodInventoryItem", _podInventoryItem);
			toReturn.Add("PodPackage", _podPackage);
			toReturn.Add("PodRoom", _podRoom);
			toReturn.Add("PodTerritory", _podTerritory);
			toReturn.Add("PodTest", _podTest);
			toReturn.Add("SalesRepPodAssigments", _salesRepPodAssigments);
			toReturn.Add("AccountCollectionViaEventNote", _accountCollectionViaEventNote);
			toReturn.Add("EventsCollectionViaEventPod", _eventsCollectionViaEventPod);
			toReturn.Add("EventsCollectionViaEventStaffAssignment", _eventsCollectionViaEventStaffAssignment);
			toReturn.Add("ItemCollectionViaPodInventoryItem", _itemCollectionViaPodInventoryItem);
			toReturn.Add("OrganizationRoleUserCollectionViaEventStaffAssignment__", _organizationRoleUserCollectionViaEventStaffAssignment__);
			toReturn.Add("OrganizationRoleUserCollectionViaSalesRepPodAssigments", _organizationRoleUserCollectionViaSalesRepPodAssigments);
			toReturn.Add("OrganizationRoleUserCollectionViaPodDefaultTeam", _organizationRoleUserCollectionViaPodDefaultTeam);
			toReturn.Add("OrganizationRoleUserCollectionViaEventStaffAssignment_", _organizationRoleUserCollectionViaEventStaffAssignment_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventNote", _organizationRoleUserCollectionViaEventNote);
			toReturn.Add("OrganizationRoleUserCollectionViaEventNote_", _organizationRoleUserCollectionViaEventNote_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventStaffAssignment", _organizationRoleUserCollectionViaEventStaffAssignment);
			toReturn.Add("PackageCollectionViaPodPackage", _packageCollectionViaPodPackage);
			toReturn.Add("PhysicianProfileCollectionViaPhysicianPod", _physicianProfileCollectionViaPhysicianPod);
			toReturn.Add("StaffEventRoleCollectionViaPodDefaultTeam", _staffEventRoleCollectionViaPodDefaultTeam);
			toReturn.Add("StaffEventRoleCollectionViaEventStaffAssignment", _staffEventRoleCollectionViaEventStaffAssignment);
			toReturn.Add("TerritoryCollectionViaPodTerritory", _territoryCollectionViaPodTerritory);
			toReturn.Add("TerritoryCollectionViaEventPod", _territoryCollectionViaEventPod);
			toReturn.Add("TestCollectionViaPodTest", _testCollectionViaPodTest);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventNote!=null)
			{
				_eventNote.ActiveContext = base.ActiveContext;
			}
			if(_eventPod!=null)
			{
				_eventPod.ActiveContext = base.ActiveContext;
			}
			if(_eventStaffAssignment!=null)
			{
				_eventStaffAssignment.ActiveContext = base.ActiveContext;
			}
			if(_physicianPod!=null)
			{
				_physicianPod.ActiveContext = base.ActiveContext;
			}
			if(_podDefaultTeam!=null)
			{
				_podDefaultTeam.ActiveContext = base.ActiveContext;
			}
			if(_podInventoryItem!=null)
			{
				_podInventoryItem.ActiveContext = base.ActiveContext;
			}
			if(_podPackage!=null)
			{
				_podPackage.ActiveContext = base.ActiveContext;
			}
			if(_podRoom!=null)
			{
				_podRoom.ActiveContext = base.ActiveContext;
			}
			if(_podTerritory!=null)
			{
				_podTerritory.ActiveContext = base.ActiveContext;
			}
			if(_podTest!=null)
			{
				_podTest.ActiveContext = base.ActiveContext;
			}
			if(_salesRepPodAssigments!=null)
			{
				_salesRepPodAssigments.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaEventNote!=null)
			{
				_accountCollectionViaEventNote.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventPod!=null)
			{
				_eventsCollectionViaEventPod.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventStaffAssignment!=null)
			{
				_eventsCollectionViaEventStaffAssignment.ActiveContext = base.ActiveContext;
			}
			if(_itemCollectionViaPodInventoryItem!=null)
			{
				_itemCollectionViaPodInventoryItem.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventStaffAssignment__!=null)
			{
				_organizationRoleUserCollectionViaEventStaffAssignment__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaSalesRepPodAssigments!=null)
			{
				_organizationRoleUserCollectionViaSalesRepPodAssigments.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPodDefaultTeam!=null)
			{
				_organizationRoleUserCollectionViaPodDefaultTeam.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventStaffAssignment_!=null)
			{
				_organizationRoleUserCollectionViaEventStaffAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventNote!=null)
			{
				_organizationRoleUserCollectionViaEventNote.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventNote_!=null)
			{
				_organizationRoleUserCollectionViaEventNote_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventStaffAssignment!=null)
			{
				_organizationRoleUserCollectionViaEventStaffAssignment.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaPodPackage!=null)
			{
				_packageCollectionViaPodPackage.ActiveContext = base.ActiveContext;
			}
			if(_physicianProfileCollectionViaPhysicianPod!=null)
			{
				_physicianProfileCollectionViaPhysicianPod.ActiveContext = base.ActiveContext;
			}
			if(_staffEventRoleCollectionViaPodDefaultTeam!=null)
			{
				_staffEventRoleCollectionViaPodDefaultTeam.ActiveContext = base.ActiveContext;
			}
			if(_staffEventRoleCollectionViaEventStaffAssignment!=null)
			{
				_staffEventRoleCollectionViaEventStaffAssignment.ActiveContext = base.ActiveContext;
			}
			if(_territoryCollectionViaPodTerritory!=null)
			{
				_territoryCollectionViaPodTerritory.ActiveContext = base.ActiveContext;
			}
			if(_territoryCollectionViaEventPod!=null)
			{
				_territoryCollectionViaEventPod.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaPodTest!=null)
			{
				_testCollectionViaPodTest.ActiveContext = base.ActiveContext;
			}
			if(_organization!=null)
			{
				_organization.ActiveContext = base.ActiveContext;
			}
			if(_vanDetails!=null)
			{
				_vanDetails.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventNote = null;
			_eventPod = null;
			_eventStaffAssignment = null;
			_physicianPod = null;
			_podDefaultTeam = null;
			_podInventoryItem = null;
			_podPackage = null;
			_podRoom = null;
			_podTerritory = null;
			_podTest = null;
			_salesRepPodAssigments = null;
			_accountCollectionViaEventNote = null;
			_eventsCollectionViaEventPod = null;
			_eventsCollectionViaEventStaffAssignment = null;
			_itemCollectionViaPodInventoryItem = null;
			_organizationRoleUserCollectionViaEventStaffAssignment__ = null;
			_organizationRoleUserCollectionViaSalesRepPodAssigments = null;
			_organizationRoleUserCollectionViaPodDefaultTeam = null;
			_organizationRoleUserCollectionViaEventStaffAssignment_ = null;
			_organizationRoleUserCollectionViaEventNote = null;
			_organizationRoleUserCollectionViaEventNote_ = null;
			_organizationRoleUserCollectionViaEventStaffAssignment = null;
			_packageCollectionViaPodPackage = null;
			_physicianProfileCollectionViaPhysicianPod = null;
			_staffEventRoleCollectionViaPodDefaultTeam = null;
			_staffEventRoleCollectionViaEventStaffAssignment = null;
			_territoryCollectionViaPodTerritory = null;
			_territoryCollectionViaEventPod = null;
			_testCollectionViaPodTest = null;
			_organization = null;
			_vanDetails = null;

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

			_fieldsCustomProperties.Add("PodId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VanId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PodProcessingCapacity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefault", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnableKynIntegration", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsBloodworkFormAttached", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", PodDetailsEntity.Relations.OrganizationEntityUsingOrganizationId, true, signalRelatedEntity, "PodDetails", resetFKFields, new int[] { (int)PodDetailsFieldIndex.OrganizationId } );		
			_organization = null;
		}

		/// <summary> setups the sync logic for member _organization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganization(IEntity2 relatedEntity)
		{
			if(_organization!=relatedEntity)
			{
				DesetupSyncOrganization(true, true);
				_organization = (OrganizationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", PodDetailsEntity.Relations.OrganizationEntityUsingOrganizationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _vanDetails</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncVanDetails(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _vanDetails, new PropertyChangedEventHandler( OnVanDetailsPropertyChanged ), "VanDetails", PodDetailsEntity.Relations.VanDetailsEntityUsingVanId, true, signalRelatedEntity, "PodDetails", resetFKFields, new int[] { (int)PodDetailsFieldIndex.VanId } );		
			_vanDetails = null;
		}

		/// <summary> setups the sync logic for member _vanDetails</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncVanDetails(IEntity2 relatedEntity)
		{
			if(_vanDetails!=relatedEntity)
			{
				DesetupSyncVanDetails(true, true);
				_vanDetails = (VanDetailsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _vanDetails, new PropertyChangedEventHandler( OnVanDetailsPropertyChanged ), "VanDetails", PodDetailsEntity.Relations.VanDetailsEntityUsingVanId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnVanDetailsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PodDetailsEntity</param>
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
		public  static PodDetailsRelations Relations
		{
			get	{ return new PodDetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventNote' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventNote
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventNoteEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventNote")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.EventNoteEntity, 0, null, null, null, null, "EventNote", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPod' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPod
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPod")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.EventPodEntity, 0, null, null, null, null, "EventPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventStaffAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventStaffAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventStaffAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventStaffAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventStaffAssignment")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.EventStaffAssignmentEntity, 0, null, null, null, null, "EventStaffAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianPod' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianPod
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPodEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianPod")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.PhysicianPodEntity, 0, null, null, null, null, "PhysicianPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDefaultTeam' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDefaultTeam
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodDefaultTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDefaultTeamEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodDefaultTeam")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.PodDefaultTeamEntity, 0, null, null, null, null, "PodDefaultTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodInventoryItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodInventoryItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodInventoryItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodInventoryItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodInventoryItem")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.PodInventoryItemEntity, 0, null, null, null, null, "PodInventoryItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodPackage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodPackage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodPackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodPackage")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.PodPackageEntity, 0, null, null, null, null, "PodPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodRoom' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodRoom
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodRoom")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.PodRoomEntity, 0, null, null, null, null, "PodRoom", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodTerritory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodTerritory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTerritoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodTerritory")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.PodTerritoryEntity, 0, null, null, null, null, "PodTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodTest")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.PodTestEntity, 0, null, null, null, null, "PodTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SalesRepPodAssigments' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSalesRepPodAssigments
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SalesRepPodAssigmentsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SalesRepPodAssigmentsEntityFactory))),
					(IEntityRelation)GetRelationsForField("SalesRepPodAssigments")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.SalesRepPodAssigmentsEntity, 0, null, null, null, null, "SalesRepPodAssigments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaEventNote
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventNoteEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventNote_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaEventNote"), null, "AccountCollectionViaEventNote", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventPod
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventPodEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventPod_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventPod"), null, "EventsCollectionViaEventPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventStaffAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventStaffAssignment"), null, "EventsCollectionViaEventStaffAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Item' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathItemCollectionViaPodInventoryItem
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.PodInventoryItemEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "PodInventoryItem_");
				return new PrefetchPathElement2(new EntityCollection<ItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.ItemEntity, 0, null, null, GetRelationsForField("ItemCollectionViaPodInventoryItem"), null, "ItemCollectionViaPodInventoryItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventStaffAssignment__
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventStaffAssignment__"), null, "OrganizationRoleUserCollectionViaEventStaffAssignment__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaSalesRepPodAssigments
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.SalesRepPodAssigmentsEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "SalesRepPodAssigments_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaSalesRepPodAssigments"), null, "OrganizationRoleUserCollectionViaSalesRepPodAssigments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPodDefaultTeam
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.PodDefaultTeamEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "PodDefaultTeam_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPodDefaultTeam"), null, "OrganizationRoleUserCollectionViaPodDefaultTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventStaffAssignment_
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventStaffAssignment_"), null, "OrganizationRoleUserCollectionViaEventStaffAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventNote
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventNoteEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventNote_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventNote"), null, "OrganizationRoleUserCollectionViaEventNote", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventNote_
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventNoteEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventNote_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventNote_"), null, "OrganizationRoleUserCollectionViaEventNote_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventStaffAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventStaffAssignment"), null, "OrganizationRoleUserCollectionViaEventStaffAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaPodPackage
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.PodPackageEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "PodPackage_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaPodPackage"), null, "PackageCollectionViaPodPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfileCollectionViaPhysicianPod
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.PhysicianPodEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianPod_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, GetRelationsForField("PhysicianProfileCollectionViaPhysicianPod"), null, "PhysicianProfileCollectionViaPhysicianPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StaffEventRole' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStaffEventRoleCollectionViaPodDefaultTeam
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.PodDefaultTeamEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "PodDefaultTeam_");
				return new PrefetchPathElement2(new EntityCollection<StaffEventRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.StaffEventRoleEntity, 0, null, null, GetRelationsForField("StaffEventRoleCollectionViaPodDefaultTeam"), null, "StaffEventRoleCollectionViaPodDefaultTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StaffEventRole' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStaffEventRoleCollectionViaEventStaffAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventStaffAssignmentEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<StaffEventRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.StaffEventRoleEntity, 0, null, null, GetRelationsForField("StaffEventRoleCollectionViaEventStaffAssignment"), null, "StaffEventRoleCollectionViaEventStaffAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Territory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTerritoryCollectionViaPodTerritory
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.PodTerritoryEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "PodTerritory_");
				return new PrefetchPathElement2(new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.TerritoryEntity, 0, null, null, GetRelationsForField("TerritoryCollectionViaPodTerritory"), null, "TerritoryCollectionViaPodTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Territory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTerritoryCollectionViaEventPod
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.EventPodEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "EventPod_");
				return new PrefetchPathElement2(new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.TerritoryEntity, 0, null, null, GetRelationsForField("TerritoryCollectionViaEventPod"), null, "TerritoryCollectionViaEventPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaPodTest
		{
			get
			{
				IEntityRelation intermediateRelation = PodDetailsEntity.Relations.PodTestEntityUsingPodId;
				intermediateRelation.SetAliases(string.Empty, "PodTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaPodTest"), null, "TestCollectionViaPodTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'VanDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathVanDetails
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(VanDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("VanDetails")[0], (int)Falcon.Data.EntityType.PodDetailsEntity, (int)Falcon.Data.EntityType.VanDetailsEntity, 0, null, null, null, null, "VanDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PodDetailsEntity.CustomProperties;}
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
			get { return PodDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The PodId property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."PodID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PodId
		{
			get { return (System.Int64)GetValue((int)PodDetailsFieldIndex.PodId, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.PodId, value); }
		}

		/// <summary> The Name property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)PodDetailsFieldIndex.Name, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)PodDetailsFieldIndex.Description, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.Description, value); }
		}

		/// <summary> The VanId property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."VanID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 VanId
		{
			get { return (System.Int64)GetValue((int)PodDetailsFieldIndex.VanId, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.VanId, value); }
		}

		/// <summary> The PodProcessingCapacity property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."PodProcessingCapacity"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PodProcessingCapacity
		{
			get { return (System.Int32)GetValue((int)PodDetailsFieldIndex.PodProcessingCapacity, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.PodProcessingCapacity, value); }
		}

		/// <summary> The IsActive property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)PodDetailsFieldIndex.IsActive, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.IsActive, value); }
		}

		/// <summary> The IsDefault property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."IsDefault"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefault
		{
			get { return (System.Boolean)GetValue((int)PodDetailsFieldIndex.IsDefault, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.IsDefault, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."CreatedByOrgRoleUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PodDetailsFieldIndex.CreatedByOrgRoleUserId, false); }
			set	{ SetValue((int)PodDetailsFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The CreatedOn property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedOn
		{
			get { return (System.DateTime)GetValue((int)PodDetailsFieldIndex.CreatedOn, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.CreatedOn, value); }
		}

		/// <summary> The UpdatedByOrgRoleUserId property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."UpdatedByOrgRoleUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UpdatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PodDetailsFieldIndex.UpdatedByOrgRoleUserId, false); }
			set	{ SetValue((int)PodDetailsFieldIndex.UpdatedByOrgRoleUserId, value); }
		}

		/// <summary> The UpdatedOn property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."UpdatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> UpdatedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PodDetailsFieldIndex.UpdatedOn, false); }
			set	{ SetValue((int)PodDetailsFieldIndex.UpdatedOn, value); }
		}

		/// <summary> The OrganizationId property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."OrganizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> OrganizationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PodDetailsFieldIndex.OrganizationId, false); }
			set	{ SetValue((int)PodDetailsFieldIndex.OrganizationId, value); }
		}

		/// <summary> The EnableKynIntegration property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."EnableKynIntegration"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean EnableKynIntegration
		{
			get { return (System.Boolean)GetValue((int)PodDetailsFieldIndex.EnableKynIntegration, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.EnableKynIntegration, value); }
		}

		/// <summary> The IsBloodworkFormAttached property of the Entity PodDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodDetails"."IsBloodworkFormAttached"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsBloodworkFormAttached
		{
			get { return (System.Boolean)GetValue((int)PodDetailsFieldIndex.IsBloodworkFormAttached, true); }
			set	{ SetValue((int)PodDetailsFieldIndex.IsBloodworkFormAttached, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventNoteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventNoteEntity))]
		public virtual EntityCollection<EventNoteEntity> EventNote
		{
			get
			{
				if(_eventNote==null)
				{
					_eventNote = new EntityCollection<EventNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventNoteEntityFactory)));
					_eventNote.SetContainingEntityInfo(this, "PodDetails");
				}
				return _eventNote;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPodEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPodEntity))]
		public virtual EntityCollection<EventPodEntity> EventPod
		{
			get
			{
				if(_eventPod==null)
				{
					_eventPod = new EntityCollection<EventPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodEntityFactory)));
					_eventPod.SetContainingEntityInfo(this, "PodDetails");
				}
				return _eventPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventStaffAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventStaffAssignmentEntity))]
		public virtual EntityCollection<EventStaffAssignmentEntity> EventStaffAssignment
		{
			get
			{
				if(_eventStaffAssignment==null)
				{
					_eventStaffAssignment = new EntityCollection<EventStaffAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventStaffAssignmentEntityFactory)));
					_eventStaffAssignment.SetContainingEntityInfo(this, "PodDetails");
				}
				return _eventStaffAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianPodEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianPodEntity))]
		public virtual EntityCollection<PhysicianPodEntity> PhysicianPod
		{
			get
			{
				if(_physicianPod==null)
				{
					_physicianPod = new EntityCollection<PhysicianPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPodEntityFactory)));
					_physicianPod.SetContainingEntityInfo(this, "PodDetails");
				}
				return _physicianPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDefaultTeamEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDefaultTeamEntity))]
		public virtual EntityCollection<PodDefaultTeamEntity> PodDefaultTeam
		{
			get
			{
				if(_podDefaultTeam==null)
				{
					_podDefaultTeam = new EntityCollection<PodDefaultTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDefaultTeamEntityFactory)));
					_podDefaultTeam.SetContainingEntityInfo(this, "PodDetails");
				}
				return _podDefaultTeam;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodInventoryItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodInventoryItemEntity))]
		public virtual EntityCollection<PodInventoryItemEntity> PodInventoryItem
		{
			get
			{
				if(_podInventoryItem==null)
				{
					_podInventoryItem = new EntityCollection<PodInventoryItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodInventoryItemEntityFactory)));
					_podInventoryItem.SetContainingEntityInfo(this, "PodDetails");
				}
				return _podInventoryItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodPackageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodPackageEntity))]
		public virtual EntityCollection<PodPackageEntity> PodPackage
		{
			get
			{
				if(_podPackage==null)
				{
					_podPackage = new EntityCollection<PodPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodPackageEntityFactory)));
					_podPackage.SetContainingEntityInfo(this, "PodDetails");
				}
				return _podPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodRoomEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodRoomEntity))]
		public virtual EntityCollection<PodRoomEntity> PodRoom
		{
			get
			{
				if(_podRoom==null)
				{
					_podRoom = new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory)));
					_podRoom.SetContainingEntityInfo(this, "PodDetails");
				}
				return _podRoom;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodTerritoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodTerritoryEntity))]
		public virtual EntityCollection<PodTerritoryEntity> PodTerritory
		{
			get
			{
				if(_podTerritory==null)
				{
					_podTerritory = new EntityCollection<PodTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTerritoryEntityFactory)));
					_podTerritory.SetContainingEntityInfo(this, "PodDetails");
				}
				return _podTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodTestEntity))]
		public virtual EntityCollection<PodTestEntity> PodTest
		{
			get
			{
				if(_podTest==null)
				{
					_podTest = new EntityCollection<PodTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTestEntityFactory)));
					_podTest.SetContainingEntityInfo(this, "PodDetails");
				}
				return _podTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SalesRepPodAssigmentsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SalesRepPodAssigmentsEntity))]
		public virtual EntityCollection<SalesRepPodAssigmentsEntity> SalesRepPodAssigments
		{
			get
			{
				if(_salesRepPodAssigments==null)
				{
					_salesRepPodAssigments = new EntityCollection<SalesRepPodAssigmentsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SalesRepPodAssigmentsEntityFactory)));
					_salesRepPodAssigments.SetContainingEntityInfo(this, "PodDetails");
				}
				return _salesRepPodAssigments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaEventNote
		{
			get
			{
				if(_accountCollectionViaEventNote==null)
				{
					_accountCollectionViaEventNote = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaEventNote.IsReadOnly=true;
				}
				return _accountCollectionViaEventNote;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventPod
		{
			get
			{
				if(_eventsCollectionViaEventPod==null)
				{
					_eventsCollectionViaEventPod = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventPod.IsReadOnly=true;
				}
				return _eventsCollectionViaEventPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventStaffAssignment
		{
			get
			{
				if(_eventsCollectionViaEventStaffAssignment==null)
				{
					_eventsCollectionViaEventStaffAssignment = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventStaffAssignment.IsReadOnly=true;
				}
				return _eventsCollectionViaEventStaffAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ItemEntity))]
		public virtual EntityCollection<ItemEntity> ItemCollectionViaPodInventoryItem
		{
			get
			{
				if(_itemCollectionViaPodInventoryItem==null)
				{
					_itemCollectionViaPodInventoryItem = new EntityCollection<ItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ItemEntityFactory)));
					_itemCollectionViaPodInventoryItem.IsReadOnly=true;
				}
				return _itemCollectionViaPodInventoryItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventStaffAssignment__
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventStaffAssignment__==null)
				{
					_organizationRoleUserCollectionViaEventStaffAssignment__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventStaffAssignment__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventStaffAssignment__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaSalesRepPodAssigments
		{
			get
			{
				if(_organizationRoleUserCollectionViaSalesRepPodAssigments==null)
				{
					_organizationRoleUserCollectionViaSalesRepPodAssigments = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaSalesRepPodAssigments.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaSalesRepPodAssigments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPodDefaultTeam
		{
			get
			{
				if(_organizationRoleUserCollectionViaPodDefaultTeam==null)
				{
					_organizationRoleUserCollectionViaPodDefaultTeam = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPodDefaultTeam.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPodDefaultTeam;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventStaffAssignment_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventStaffAssignment_==null)
				{
					_organizationRoleUserCollectionViaEventStaffAssignment_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventStaffAssignment_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventStaffAssignment_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventNote
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventNote==null)
				{
					_organizationRoleUserCollectionViaEventNote = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventNote.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventNote;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventNote_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventNote_==null)
				{
					_organizationRoleUserCollectionViaEventNote_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventNote_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventNote_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventStaffAssignment
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventStaffAssignment==null)
				{
					_organizationRoleUserCollectionViaEventStaffAssignment = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventStaffAssignment.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventStaffAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaPodPackage
		{
			get
			{
				if(_packageCollectionViaPodPackage==null)
				{
					_packageCollectionViaPodPackage = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaPodPackage.IsReadOnly=true;
				}
				return _packageCollectionViaPodPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianProfileEntity))]
		public virtual EntityCollection<PhysicianProfileEntity> PhysicianProfileCollectionViaPhysicianPod
		{
			get
			{
				if(_physicianProfileCollectionViaPhysicianPod==null)
				{
					_physicianProfileCollectionViaPhysicianPod = new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory)));
					_physicianProfileCollectionViaPhysicianPod.IsReadOnly=true;
				}
				return _physicianProfileCollectionViaPhysicianPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StaffEventRoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StaffEventRoleEntity))]
		public virtual EntityCollection<StaffEventRoleEntity> StaffEventRoleCollectionViaPodDefaultTeam
		{
			get
			{
				if(_staffEventRoleCollectionViaPodDefaultTeam==null)
				{
					_staffEventRoleCollectionViaPodDefaultTeam = new EntityCollection<StaffEventRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory)));
					_staffEventRoleCollectionViaPodDefaultTeam.IsReadOnly=true;
				}
				return _staffEventRoleCollectionViaPodDefaultTeam;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StaffEventRoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StaffEventRoleEntity))]
		public virtual EntityCollection<StaffEventRoleEntity> StaffEventRoleCollectionViaEventStaffAssignment
		{
			get
			{
				if(_staffEventRoleCollectionViaEventStaffAssignment==null)
				{
					_staffEventRoleCollectionViaEventStaffAssignment = new EntityCollection<StaffEventRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory)));
					_staffEventRoleCollectionViaEventStaffAssignment.IsReadOnly=true;
				}
				return _staffEventRoleCollectionViaEventStaffAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TerritoryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TerritoryEntity))]
		public virtual EntityCollection<TerritoryEntity> TerritoryCollectionViaPodTerritory
		{
			get
			{
				if(_territoryCollectionViaPodTerritory==null)
				{
					_territoryCollectionViaPodTerritory = new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory)));
					_territoryCollectionViaPodTerritory.IsReadOnly=true;
				}
				return _territoryCollectionViaPodTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TerritoryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TerritoryEntity))]
		public virtual EntityCollection<TerritoryEntity> TerritoryCollectionViaEventPod
		{
			get
			{
				if(_territoryCollectionViaEventPod==null)
				{
					_territoryCollectionViaEventPod = new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory)));
					_territoryCollectionViaEventPod.IsReadOnly=true;
				}
				return _territoryCollectionViaEventPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaPodTest
		{
			get
			{
				if(_testCollectionViaPodTest==null)
				{
					_testCollectionViaPodTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaPodTest.IsReadOnly=true;
				}
				return _testCollectionViaPodTest;
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationEntity Organization
		{
			get
			{
				return _organization;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganization(value);
				}
				else
				{
					if(value==null)
					{
						if(_organization != null)
						{
							_organization.UnsetRelatedEntity(this, "PodDetails");
						}
					}
					else
					{
						if(_organization!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PodDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'VanDetailsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual VanDetailsEntity VanDetails
		{
			get
			{
				return _vanDetails;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncVanDetails(value);
				}
				else
				{
					if(value==null)
					{
						if(_vanDetails != null)
						{
							_vanDetails.UnsetRelatedEntity(this, "PodDetails");
						}
					}
					else
					{
						if(_vanDetails!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PodDetails");
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
			get { return (int)Falcon.Data.EntityType.PodDetailsEntity; }
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
