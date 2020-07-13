///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'StaffEventRole'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class StaffEventRoleEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventStaffAssignmentEntity> _eventStaffAssignment;
		private EntityCollection<PodDefaultTeamEntity> _podDefaultTeam;
		private EntityCollection<StaffEventRoleTestEntity> _staffEventRoleTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventStaffAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventStaffAssignment__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPodDefaultTeam;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventStaffAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventStaffAssignment_;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaPodDefaultTeam;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaEventStaffAssignment;
		private EntityCollection<TestEntity> _testCollectionViaStaffEventRoleTest;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name EventStaffAssignment</summary>
			public static readonly string EventStaffAssignment = "EventStaffAssignment";
			/// <summary>Member name PodDefaultTeam</summary>
			public static readonly string PodDefaultTeam = "PodDefaultTeam";
			/// <summary>Member name StaffEventRoleTest</summary>
			public static readonly string StaffEventRoleTest = "StaffEventRoleTest";
			/// <summary>Member name EventsCollectionViaEventStaffAssignment</summary>
			public static readonly string EventsCollectionViaEventStaffAssignment = "EventsCollectionViaEventStaffAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventStaffAssignment__</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventStaffAssignment__ = "OrganizationRoleUserCollectionViaEventStaffAssignment__";
			/// <summary>Member name OrganizationRoleUserCollectionViaPodDefaultTeam</summary>
			public static readonly string OrganizationRoleUserCollectionViaPodDefaultTeam = "OrganizationRoleUserCollectionViaPodDefaultTeam";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventStaffAssignment</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventStaffAssignment = "OrganizationRoleUserCollectionViaEventStaffAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventStaffAssignment_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventStaffAssignment_ = "OrganizationRoleUserCollectionViaEventStaffAssignment_";
			/// <summary>Member name PodDetailsCollectionViaPodDefaultTeam</summary>
			public static readonly string PodDetailsCollectionViaPodDefaultTeam = "PodDetailsCollectionViaPodDefaultTeam";
			/// <summary>Member name PodDetailsCollectionViaEventStaffAssignment</summary>
			public static readonly string PodDetailsCollectionViaEventStaffAssignment = "PodDetailsCollectionViaEventStaffAssignment";
			/// <summary>Member name TestCollectionViaStaffEventRoleTest</summary>
			public static readonly string TestCollectionViaStaffEventRoleTest = "TestCollectionViaStaffEventRoleTest";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static StaffEventRoleEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public StaffEventRoleEntity():base("StaffEventRoleEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public StaffEventRoleEntity(IEntityFields2 fields):base("StaffEventRoleEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this StaffEventRoleEntity</param>
		public StaffEventRoleEntity(IValidator validator):base("StaffEventRoleEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="staffEventRoleId">PK value for StaffEventRole which data should be fetched into this StaffEventRole object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public StaffEventRoleEntity(System.Int64 staffEventRoleId):base("StaffEventRoleEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.StaffEventRoleId = staffEventRoleId;
		}

		/// <summary> CTor</summary>
		/// <param name="staffEventRoleId">PK value for StaffEventRole which data should be fetched into this StaffEventRole object</param>
		/// <param name="validator">The custom validator object for this StaffEventRoleEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public StaffEventRoleEntity(System.Int64 staffEventRoleId, IValidator validator):base("StaffEventRoleEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.StaffEventRoleId = staffEventRoleId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected StaffEventRoleEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventStaffAssignment = (EntityCollection<EventStaffAssignmentEntity>)info.GetValue("_eventStaffAssignment", typeof(EntityCollection<EventStaffAssignmentEntity>));
				_podDefaultTeam = (EntityCollection<PodDefaultTeamEntity>)info.GetValue("_podDefaultTeam", typeof(EntityCollection<PodDefaultTeamEntity>));
				_staffEventRoleTest = (EntityCollection<StaffEventRoleTestEntity>)info.GetValue("_staffEventRoleTest", typeof(EntityCollection<StaffEventRoleTestEntity>));
				_eventsCollectionViaEventStaffAssignment = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventStaffAssignment", typeof(EntityCollection<EventsEntity>));
				_organizationRoleUserCollectionViaEventStaffAssignment__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventStaffAssignment__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPodDefaultTeam = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPodDefaultTeam", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventStaffAssignment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventStaffAssignment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventStaffAssignment_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventStaffAssignment_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_podDetailsCollectionViaPodDefaultTeam = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaPodDefaultTeam", typeof(EntityCollection<PodDetailsEntity>));
				_podDetailsCollectionViaEventStaffAssignment = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaEventStaffAssignment", typeof(EntityCollection<PodDetailsEntity>));
				_testCollectionViaStaffEventRoleTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaStaffEventRoleTest", typeof(EntityCollection<TestEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((StaffEventRoleFieldIndex)fieldIndex)
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

				case "EventStaffAssignment":
					this.EventStaffAssignment.Add((EventStaffAssignmentEntity)entity);
					break;
				case "PodDefaultTeam":
					this.PodDefaultTeam.Add((PodDefaultTeamEntity)entity);
					break;
				case "StaffEventRoleTest":
					this.StaffEventRoleTest.Add((StaffEventRoleTestEntity)entity);
					break;
				case "EventsCollectionViaEventStaffAssignment":
					this.EventsCollectionViaEventStaffAssignment.IsReadOnly = false;
					this.EventsCollectionViaEventStaffAssignment.Add((EventsEntity)entity);
					this.EventsCollectionViaEventStaffAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment__":
					this.OrganizationRoleUserCollectionViaEventStaffAssignment__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventStaffAssignment__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventStaffAssignment__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPodDefaultTeam":
					this.OrganizationRoleUserCollectionViaPodDefaultTeam.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPodDefaultTeam.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPodDefaultTeam.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment":
					this.OrganizationRoleUserCollectionViaEventStaffAssignment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventStaffAssignment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventStaffAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment_":
					this.OrganizationRoleUserCollectionViaEventStaffAssignment_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventStaffAssignment_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventStaffAssignment_.IsReadOnly = true;
					break;
				case "PodDetailsCollectionViaPodDefaultTeam":
					this.PodDetailsCollectionViaPodDefaultTeam.IsReadOnly = false;
					this.PodDetailsCollectionViaPodDefaultTeam.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaPodDefaultTeam.IsReadOnly = true;
					break;
				case "PodDetailsCollectionViaEventStaffAssignment":
					this.PodDetailsCollectionViaEventStaffAssignment.IsReadOnly = false;
					this.PodDetailsCollectionViaEventStaffAssignment.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaEventStaffAssignment.IsReadOnly = true;
					break;
				case "TestCollectionViaStaffEventRoleTest":
					this.TestCollectionViaStaffEventRoleTest.IsReadOnly = false;
					this.TestCollectionViaStaffEventRoleTest.Add((TestEntity)entity);
					this.TestCollectionViaStaffEventRoleTest.IsReadOnly = true;
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
			return StaffEventRoleEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "EventStaffAssignment":
					toReturn.Add(StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId);
					break;
				case "PodDefaultTeam":
					toReturn.Add(StaffEventRoleEntity.Relations.PodDefaultTeamEntityUsingEventRoleId);
					break;
				case "StaffEventRoleTest":
					toReturn.Add(StaffEventRoleEntity.Relations.StaffEventRoleTestEntityUsingStaffEventRoleId);
					break;
				case "EventsCollectionViaEventStaffAssignment":
					toReturn.Add(StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId, "StaffEventRoleEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.EventsEntityUsingEventId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment__":
					toReturn.Add(StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId, "StaffEventRoleEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.OrganizationRoleUserEntityUsingScheduledByOrgRoleUserId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPodDefaultTeam":
					toReturn.Add(StaffEventRoleEntity.Relations.PodDefaultTeamEntityUsingEventRoleId, "StaffEventRoleEntity__", "PodDefaultTeam_", JoinHint.None);
					toReturn.Add(PodDefaultTeamEntity.Relations.OrganizationRoleUserEntityUsingOrgnizationRoleUserId, "PodDefaultTeam_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment":
					toReturn.Add(StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId, "StaffEventRoleEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.OrganizationRoleUserEntityUsingScheduledStaffOrgRoleUserId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventStaffAssignment_":
					toReturn.Add(StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId, "StaffEventRoleEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.OrganizationRoleUserEntityUsingActualStaffOrgRoleUserId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "PodDetailsCollectionViaPodDefaultTeam":
					toReturn.Add(StaffEventRoleEntity.Relations.PodDefaultTeamEntityUsingEventRoleId, "StaffEventRoleEntity__", "PodDefaultTeam_", JoinHint.None);
					toReturn.Add(PodDefaultTeamEntity.Relations.PodDetailsEntityUsingPodId, "PodDefaultTeam_", string.Empty, JoinHint.None);
					break;
				case "PodDetailsCollectionViaEventStaffAssignment":
					toReturn.Add(StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId, "StaffEventRoleEntity__", "EventStaffAssignment_", JoinHint.None);
					toReturn.Add(EventStaffAssignmentEntity.Relations.PodDetailsEntityUsingPodId, "EventStaffAssignment_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaStaffEventRoleTest":
					toReturn.Add(StaffEventRoleEntity.Relations.StaffEventRoleTestEntityUsingStaffEventRoleId, "StaffEventRoleEntity__", "StaffEventRoleTest_", JoinHint.None);
					toReturn.Add(StaffEventRoleTestEntity.Relations.TestEntityUsingTestId, "StaffEventRoleTest_", string.Empty, JoinHint.None);
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

				case "EventStaffAssignment":
					this.EventStaffAssignment.Add((EventStaffAssignmentEntity)relatedEntity);
					break;
				case "PodDefaultTeam":
					this.PodDefaultTeam.Add((PodDefaultTeamEntity)relatedEntity);
					break;
				case "StaffEventRoleTest":
					this.StaffEventRoleTest.Add((StaffEventRoleTestEntity)relatedEntity);
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

				case "EventStaffAssignment":
					base.PerformRelatedEntityRemoval(this.EventStaffAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodDefaultTeam":
					base.PerformRelatedEntityRemoval(this.PodDefaultTeam, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "StaffEventRoleTest":
					base.PerformRelatedEntityRemoval(this.StaffEventRoleTest, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.EventStaffAssignment);
			toReturn.Add(this.PodDefaultTeam);
			toReturn.Add(this.StaffEventRoleTest);

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
				info.AddValue("_eventStaffAssignment", ((_eventStaffAssignment!=null) && (_eventStaffAssignment.Count>0) && !this.MarkedForDeletion)?_eventStaffAssignment:null);
				info.AddValue("_podDefaultTeam", ((_podDefaultTeam!=null) && (_podDefaultTeam.Count>0) && !this.MarkedForDeletion)?_podDefaultTeam:null);
				info.AddValue("_staffEventRoleTest", ((_staffEventRoleTest!=null) && (_staffEventRoleTest.Count>0) && !this.MarkedForDeletion)?_staffEventRoleTest:null);
				info.AddValue("_eventsCollectionViaEventStaffAssignment", ((_eventsCollectionViaEventStaffAssignment!=null) && (_eventsCollectionViaEventStaffAssignment.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventStaffAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaEventStaffAssignment__", ((_organizationRoleUserCollectionViaEventStaffAssignment__!=null) && (_organizationRoleUserCollectionViaEventStaffAssignment__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventStaffAssignment__:null);
				info.AddValue("_organizationRoleUserCollectionViaPodDefaultTeam", ((_organizationRoleUserCollectionViaPodDefaultTeam!=null) && (_organizationRoleUserCollectionViaPodDefaultTeam.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPodDefaultTeam:null);
				info.AddValue("_organizationRoleUserCollectionViaEventStaffAssignment", ((_organizationRoleUserCollectionViaEventStaffAssignment!=null) && (_organizationRoleUserCollectionViaEventStaffAssignment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventStaffAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaEventStaffAssignment_", ((_organizationRoleUserCollectionViaEventStaffAssignment_!=null) && (_organizationRoleUserCollectionViaEventStaffAssignment_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventStaffAssignment_:null);
				info.AddValue("_podDetailsCollectionViaPodDefaultTeam", ((_podDetailsCollectionViaPodDefaultTeam!=null) && (_podDetailsCollectionViaPodDefaultTeam.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaPodDefaultTeam:null);
				info.AddValue("_podDetailsCollectionViaEventStaffAssignment", ((_podDetailsCollectionViaEventStaffAssignment!=null) && (_podDetailsCollectionViaEventStaffAssignment.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaEventStaffAssignment:null);
				info.AddValue("_testCollectionViaStaffEventRoleTest", ((_testCollectionViaStaffEventRoleTest!=null) && (_testCollectionViaStaffEventRoleTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaStaffEventRoleTest:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(StaffEventRoleFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(StaffEventRoleFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new StaffEventRoleRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventStaffAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventStaffAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventStaffAssignmentFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDefaultTeam' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDefaultTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDefaultTeamFields.EventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StaffEventRoleTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStaffEventRoleTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleTestFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventStaffAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventStaffAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId, "StaffEventRoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventStaffAssignment__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventStaffAssignment__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId, "StaffEventRoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPodDefaultTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPodDefaultTeam"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId, "StaffEventRoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventStaffAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventStaffAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId, "StaffEventRoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventStaffAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventStaffAssignment_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId, "StaffEventRoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaPodDefaultTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaPodDefaultTeam"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId, "StaffEventRoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaEventStaffAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaEventStaffAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId, "StaffEventRoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaStaffEventRoleTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaStaffEventRoleTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleFields.StaffEventRoleId, null, ComparisonOperator.Equal, this.StaffEventRoleId, "StaffEventRoleEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.StaffEventRoleEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventStaffAssignment);
			collectionsQueue.Enqueue(this._podDefaultTeam);
			collectionsQueue.Enqueue(this._staffEventRoleTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventStaffAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventStaffAssignment__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPodDefaultTeam);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventStaffAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventStaffAssignment_);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaPodDefaultTeam);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaEventStaffAssignment);
			collectionsQueue.Enqueue(this._testCollectionViaStaffEventRoleTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventStaffAssignment = (EntityCollection<EventStaffAssignmentEntity>) collectionsQueue.Dequeue();
			this._podDefaultTeam = (EntityCollection<PodDefaultTeamEntity>) collectionsQueue.Dequeue();
			this._staffEventRoleTest = (EntityCollection<StaffEventRoleTestEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventStaffAssignment = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventStaffAssignment__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPodDefaultTeam = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventStaffAssignment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventStaffAssignment_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaPodDefaultTeam = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaEventStaffAssignment = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaStaffEventRoleTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventStaffAssignment != null)
			{
				return true;
			}
			if (this._podDefaultTeam != null)
			{
				return true;
			}
			if (this._staffEventRoleTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventStaffAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventStaffAssignment__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPodDefaultTeam != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventStaffAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventStaffAssignment_ != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaPodDefaultTeam != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaEventStaffAssignment != null)
			{
				return true;
			}
			if (this._testCollectionViaStaffEventRoleTest != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventStaffAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventStaffAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDefaultTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDefaultTeamEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StaffEventRoleTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
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

			toReturn.Add("EventStaffAssignment", _eventStaffAssignment);
			toReturn.Add("PodDefaultTeam", _podDefaultTeam);
			toReturn.Add("StaffEventRoleTest", _staffEventRoleTest);
			toReturn.Add("EventsCollectionViaEventStaffAssignment", _eventsCollectionViaEventStaffAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaEventStaffAssignment__", _organizationRoleUserCollectionViaEventStaffAssignment__);
			toReturn.Add("OrganizationRoleUserCollectionViaPodDefaultTeam", _organizationRoleUserCollectionViaPodDefaultTeam);
			toReturn.Add("OrganizationRoleUserCollectionViaEventStaffAssignment", _organizationRoleUserCollectionViaEventStaffAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaEventStaffAssignment_", _organizationRoleUserCollectionViaEventStaffAssignment_);
			toReturn.Add("PodDetailsCollectionViaPodDefaultTeam", _podDetailsCollectionViaPodDefaultTeam);
			toReturn.Add("PodDetailsCollectionViaEventStaffAssignment", _podDetailsCollectionViaEventStaffAssignment);
			toReturn.Add("TestCollectionViaStaffEventRoleTest", _testCollectionViaStaffEventRoleTest);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventStaffAssignment!=null)
			{
				_eventStaffAssignment.ActiveContext = base.ActiveContext;
			}
			if(_podDefaultTeam!=null)
			{
				_podDefaultTeam.ActiveContext = base.ActiveContext;
			}
			if(_staffEventRoleTest!=null)
			{
				_staffEventRoleTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventStaffAssignment!=null)
			{
				_eventsCollectionViaEventStaffAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventStaffAssignment__!=null)
			{
				_organizationRoleUserCollectionViaEventStaffAssignment__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPodDefaultTeam!=null)
			{
				_organizationRoleUserCollectionViaPodDefaultTeam.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventStaffAssignment!=null)
			{
				_organizationRoleUserCollectionViaEventStaffAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventStaffAssignment_!=null)
			{
				_organizationRoleUserCollectionViaEventStaffAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaPodDefaultTeam!=null)
			{
				_podDetailsCollectionViaPodDefaultTeam.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaEventStaffAssignment!=null)
			{
				_podDetailsCollectionViaEventStaffAssignment.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaStaffEventRoleTest!=null)
			{
				_testCollectionViaStaffEventRoleTest.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventStaffAssignment = null;
			_podDefaultTeam = null;
			_staffEventRoleTest = null;
			_eventsCollectionViaEventStaffAssignment = null;
			_organizationRoleUserCollectionViaEventStaffAssignment__ = null;
			_organizationRoleUserCollectionViaPodDefaultTeam = null;
			_organizationRoleUserCollectionViaEventStaffAssignment = null;
			_organizationRoleUserCollectionViaEventStaffAssignment_ = null;
			_podDetailsCollectionViaPodDefaultTeam = null;
			_podDetailsCollectionViaEventStaffAssignment = null;
			_testCollectionViaStaffEventRoleTest = null;


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

			_fieldsCustomProperties.Add("StaffEventRoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedOn", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this StaffEventRoleEntity</param>
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
		public  static StaffEventRoleRelations Relations
		{
			get	{ return new StaffEventRoleRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventStaffAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventStaffAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventStaffAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventStaffAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventStaffAssignment")[0], (int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.EventStaffAssignmentEntity, 0, null, null, null, null, "EventStaffAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("PodDefaultTeam")[0], (int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.PodDefaultTeamEntity, 0, null, null, null, null, "PodDefaultTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StaffEventRoleTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStaffEventRoleTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<StaffEventRoleTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("StaffEventRoleTest")[0], (int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.StaffEventRoleTestEntity, 0, null, null, null, null, "StaffEventRoleTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventStaffAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventStaffAssignment"), null, "EventsCollectionViaEventStaffAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventStaffAssignment__
		{
			get
			{
				IEntityRelation intermediateRelation = StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventStaffAssignment__"), null, "OrganizationRoleUserCollectionViaEventStaffAssignment__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPodDefaultTeam
		{
			get
			{
				IEntityRelation intermediateRelation = StaffEventRoleEntity.Relations.PodDefaultTeamEntityUsingEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "PodDefaultTeam_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPodDefaultTeam"), null, "OrganizationRoleUserCollectionViaPodDefaultTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventStaffAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventStaffAssignment"), null, "OrganizationRoleUserCollectionViaEventStaffAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventStaffAssignment_
		{
			get
			{
				IEntityRelation intermediateRelation = StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventStaffAssignment_"), null, "OrganizationRoleUserCollectionViaEventStaffAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaPodDefaultTeam
		{
			get
			{
				IEntityRelation intermediateRelation = StaffEventRoleEntity.Relations.PodDefaultTeamEntityUsingEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "PodDefaultTeam_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaPodDefaultTeam"), null, "PodDetailsCollectionViaPodDefaultTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaEventStaffAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = StaffEventRoleEntity.Relations.EventStaffAssignmentEntityUsingStaffEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "EventStaffAssignment_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaEventStaffAssignment"), null, "PodDetailsCollectionViaEventStaffAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaStaffEventRoleTest
		{
			get
			{
				IEntityRelation intermediateRelation = StaffEventRoleEntity.Relations.StaffEventRoleTestEntityUsingStaffEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "StaffEventRoleTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StaffEventRoleEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaStaffEventRoleTest"), null, "TestCollectionViaStaffEventRoleTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return StaffEventRoleEntity.CustomProperties;}
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
			get { return StaffEventRoleEntity.FieldsCustomProperties;}
		}

		/// <summary> The StaffEventRoleId property of the Entity StaffEventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStaffEventRole"."StaffEventRoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 StaffEventRoleId
		{
			get { return (System.Int64)GetValue((int)StaffEventRoleFieldIndex.StaffEventRoleId, true); }
			set	{ SetValue((int)StaffEventRoleFieldIndex.StaffEventRoleId, value); }
		}

		/// <summary> The Name property of the Entity StaffEventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStaffEventRole"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)StaffEventRoleFieldIndex.Name, true); }
			set	{ SetValue((int)StaffEventRoleFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity StaffEventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStaffEventRole"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)StaffEventRoleFieldIndex.Description, true); }
			set	{ SetValue((int)StaffEventRoleFieldIndex.Description, value); }
		}

		/// <summary> The IsActive property of the Entity StaffEventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStaffEventRole"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)StaffEventRoleFieldIndex.IsActive, true); }
			set	{ SetValue((int)StaffEventRoleFieldIndex.IsActive, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity StaffEventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStaffEventRole"."CreatedByOrgRoleUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)StaffEventRoleFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)StaffEventRoleFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The CreatedOn property of the Entity StaffEventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStaffEventRole"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedOn
		{
			get { return (System.DateTime)GetValue((int)StaffEventRoleFieldIndex.CreatedOn, true); }
			set	{ SetValue((int)StaffEventRoleFieldIndex.CreatedOn, value); }
		}

		/// <summary> The UpdatedByOrgRoleUserId property of the Entity StaffEventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStaffEventRole"."UpdatedByOrgRoleUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UpdatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)StaffEventRoleFieldIndex.UpdatedByOrgRoleUserId, false); }
			set	{ SetValue((int)StaffEventRoleFieldIndex.UpdatedByOrgRoleUserId, value); }
		}

		/// <summary> The UpdatedOn property of the Entity StaffEventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStaffEventRole"."UpdatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> UpdatedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)StaffEventRoleFieldIndex.UpdatedOn, false); }
			set	{ SetValue((int)StaffEventRoleFieldIndex.UpdatedOn, value); }
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
					_eventStaffAssignment.SetContainingEntityInfo(this, "StaffEventRole");
				}
				return _eventStaffAssignment;
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
					_podDefaultTeam.SetContainingEntityInfo(this, "StaffEventRole");
				}
				return _podDefaultTeam;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StaffEventRoleTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StaffEventRoleTestEntity))]
		public virtual EntityCollection<StaffEventRoleTestEntity> StaffEventRoleTest
		{
			get
			{
				if(_staffEventRoleTest==null)
				{
					_staffEventRoleTest = new EntityCollection<StaffEventRoleTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleTestEntityFactory)));
					_staffEventRoleTest.SetContainingEntityInfo(this, "StaffEventRole");
				}
				return _staffEventRoleTest;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaPodDefaultTeam
		{
			get
			{
				if(_podDetailsCollectionViaPodDefaultTeam==null)
				{
					_podDetailsCollectionViaPodDefaultTeam = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaPodDefaultTeam.IsReadOnly=true;
				}
				return _podDetailsCollectionViaPodDefaultTeam;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaEventStaffAssignment
		{
			get
			{
				if(_podDetailsCollectionViaEventStaffAssignment==null)
				{
					_podDetailsCollectionViaEventStaffAssignment = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaEventStaffAssignment.IsReadOnly=true;
				}
				return _podDetailsCollectionViaEventStaffAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaStaffEventRoleTest
		{
			get
			{
				if(_testCollectionViaStaffEventRoleTest==null)
				{
					_testCollectionViaStaffEventRoleTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaStaffEventRoleTest.IsReadOnly=true;
				}
				return _testCollectionViaStaffEventRoleTest;
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
			get { return (int)Falcon.Data.EntityType.StaffEventRoleEntity; }
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
