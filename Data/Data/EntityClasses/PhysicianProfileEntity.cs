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
	/// Entity class which represents the entity 'PhysicianProfile'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PhysicianProfileEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerSkipReviewEntity> _customerSkipReview;
		private EntityCollection<EventCustomerEvaluationLockEntity> _eventCustomerEvaluationLock;
		private EntityCollection<PhysicianCustomerAssignmentEntity> _physicianCustomerAssignment_;
		private EntityCollection<PhysicianCustomerAssignmentEntity> _physicianCustomerAssignment;
		private EntityCollection<PhysicianEarningsEntity> _physicianEarnings;
		private EntityCollection<PhysicianEvaluationEntity> _physicianEvaluation;
		private EntityCollection<PhysicianEventAssignmentEntity> _physicianEventAssignment_;
		private EntityCollection<PhysicianEventAssignmentEntity> _physicianEventAssignment;
		private EntityCollection<PhysicianInvoiceEntity> _physicianInvoice;
		private EntityCollection<PhysicianLabTestEntity> _physicianLabTest;
		private EntityCollection<PhysicianLicenseEntity> _physicianLicense;
		private EntityCollection<PhysicianPermittedTestEntity> _physicianPermittedTest;
		private EntityCollection<PhysicianPodEntity> _physicianPod;
		private EntityCollection<ScreeningAuthorizationEntity> _screeningAuthorization;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaPhysicianEvaluation;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaPhysicianCustomerAssignment_;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaPhysicianCustomerAssignment;
		private EntityCollection<EventsEntity> _eventsCollectionViaPhysicianEventAssignment_;
		private EntityCollection<EventsEntity> _eventsCollectionViaPhysicianEventAssignment;
		private EntityCollection<PhysicianEvaluationEntity> _physicianEvaluationCollectionViaPhysicianEarnings;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaPhysicianPod;
		private EntityCollection<StateEntity> _stateCollectionViaPhysicianLicense;
		private EntityCollection<StateEntity> _stateCollectionViaPhysicianLabTest;
		private EntityCollection<TestEntity> _testCollectionViaPhysicianPermittedTest;
		private FileEntity _file_;
		private FileEntity _file;
		private MvuserClassificationEntity _mvuserClassification;
		private PhysicianSpecializationEntity _physicianSpecialization;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private PhysicianCustomerPayRateEntity _physicianCustomerPayRate;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name File_</summary>
			public static readonly string File_ = "File_";
			/// <summary>Member name File</summary>
			public static readonly string File = "File";
			/// <summary>Member name MvuserClassification</summary>
			public static readonly string MvuserClassification = "MvuserClassification";
			/// <summary>Member name PhysicianSpecialization</summary>
			public static readonly string PhysicianSpecialization = "PhysicianSpecialization";
			/// <summary>Member name CustomerSkipReview</summary>
			public static readonly string CustomerSkipReview = "CustomerSkipReview";
			/// <summary>Member name EventCustomerEvaluationLock</summary>
			public static readonly string EventCustomerEvaluationLock = "EventCustomerEvaluationLock";
			/// <summary>Member name PhysicianCustomerAssignment_</summary>
			public static readonly string PhysicianCustomerAssignment_ = "PhysicianCustomerAssignment_";
			/// <summary>Member name PhysicianCustomerAssignment</summary>
			public static readonly string PhysicianCustomerAssignment = "PhysicianCustomerAssignment";
			/// <summary>Member name PhysicianEarnings</summary>
			public static readonly string PhysicianEarnings = "PhysicianEarnings";
			/// <summary>Member name PhysicianEvaluation</summary>
			public static readonly string PhysicianEvaluation = "PhysicianEvaluation";
			/// <summary>Member name PhysicianEventAssignment_</summary>
			public static readonly string PhysicianEventAssignment_ = "PhysicianEventAssignment_";
			/// <summary>Member name PhysicianEventAssignment</summary>
			public static readonly string PhysicianEventAssignment = "PhysicianEventAssignment";
			/// <summary>Member name PhysicianInvoice</summary>
			public static readonly string PhysicianInvoice = "PhysicianInvoice";
			/// <summary>Member name PhysicianLabTest</summary>
			public static readonly string PhysicianLabTest = "PhysicianLabTest";
			/// <summary>Member name PhysicianLicense</summary>
			public static readonly string PhysicianLicense = "PhysicianLicense";
			/// <summary>Member name PhysicianPermittedTest</summary>
			public static readonly string PhysicianPermittedTest = "PhysicianPermittedTest";
			/// <summary>Member name PhysicianPod</summary>
			public static readonly string PhysicianPod = "PhysicianPod";
			/// <summary>Member name ScreeningAuthorization</summary>
			public static readonly string ScreeningAuthorization = "ScreeningAuthorization";
			/// <summary>Member name EventCustomersCollectionViaPhysicianEvaluation</summary>
			public static readonly string EventCustomersCollectionViaPhysicianEvaluation = "EventCustomersCollectionViaPhysicianEvaluation";
			/// <summary>Member name EventCustomersCollectionViaPhysicianCustomerAssignment_</summary>
			public static readonly string EventCustomersCollectionViaPhysicianCustomerAssignment_ = "EventCustomersCollectionViaPhysicianCustomerAssignment_";
			/// <summary>Member name EventCustomersCollectionViaPhysicianCustomerAssignment</summary>
			public static readonly string EventCustomersCollectionViaPhysicianCustomerAssignment = "EventCustomersCollectionViaPhysicianCustomerAssignment";
			/// <summary>Member name EventsCollectionViaPhysicianEventAssignment_</summary>
			public static readonly string EventsCollectionViaPhysicianEventAssignment_ = "EventsCollectionViaPhysicianEventAssignment_";
			/// <summary>Member name EventsCollectionViaPhysicianEventAssignment</summary>
			public static readonly string EventsCollectionViaPhysicianEventAssignment = "EventsCollectionViaPhysicianEventAssignment";
			/// <summary>Member name PhysicianEvaluationCollectionViaPhysicianEarnings</summary>
			public static readonly string PhysicianEvaluationCollectionViaPhysicianEarnings = "PhysicianEvaluationCollectionViaPhysicianEarnings";
			/// <summary>Member name PodDetailsCollectionViaPhysicianPod</summary>
			public static readonly string PodDetailsCollectionViaPhysicianPod = "PodDetailsCollectionViaPhysicianPod";
			/// <summary>Member name StateCollectionViaPhysicianLicense</summary>
			public static readonly string StateCollectionViaPhysicianLicense = "StateCollectionViaPhysicianLicense";
			/// <summary>Member name StateCollectionViaPhysicianLabTest</summary>
			public static readonly string StateCollectionViaPhysicianLabTest = "StateCollectionViaPhysicianLabTest";
			/// <summary>Member name TestCollectionViaPhysicianPermittedTest</summary>
			public static readonly string TestCollectionViaPhysicianPermittedTest = "TestCollectionViaPhysicianPermittedTest";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name PhysicianCustomerPayRate</summary>
			public static readonly string PhysicianCustomerPayRate = "PhysicianCustomerPayRate";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PhysicianProfileEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PhysicianProfileEntity():base("PhysicianProfileEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PhysicianProfileEntity(IEntityFields2 fields):base("PhysicianProfileEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PhysicianProfileEntity</param>
		public PhysicianProfileEntity(IValidator validator):base("PhysicianProfileEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="physicianId">PK value for PhysicianProfile which data should be fetched into this PhysicianProfile object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianProfileEntity(System.Int64 physicianId):base("PhysicianProfileEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PhysicianId = physicianId;
		}

		/// <summary> CTor</summary>
		/// <param name="physicianId">PK value for PhysicianProfile which data should be fetched into this PhysicianProfile object</param>
		/// <param name="validator">The custom validator object for this PhysicianProfileEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianProfileEntity(System.Int64 physicianId, IValidator validator):base("PhysicianProfileEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PhysicianId = physicianId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PhysicianProfileEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerSkipReview = (EntityCollection<CustomerSkipReviewEntity>)info.GetValue("_customerSkipReview", typeof(EntityCollection<CustomerSkipReviewEntity>));
				_eventCustomerEvaluationLock = (EntityCollection<EventCustomerEvaluationLockEntity>)info.GetValue("_eventCustomerEvaluationLock", typeof(EntityCollection<EventCustomerEvaluationLockEntity>));
				_physicianCustomerAssignment_ = (EntityCollection<PhysicianCustomerAssignmentEntity>)info.GetValue("_physicianCustomerAssignment_", typeof(EntityCollection<PhysicianCustomerAssignmentEntity>));
				_physicianCustomerAssignment = (EntityCollection<PhysicianCustomerAssignmentEntity>)info.GetValue("_physicianCustomerAssignment", typeof(EntityCollection<PhysicianCustomerAssignmentEntity>));
				_physicianEarnings = (EntityCollection<PhysicianEarningsEntity>)info.GetValue("_physicianEarnings", typeof(EntityCollection<PhysicianEarningsEntity>));
				_physicianEvaluation = (EntityCollection<PhysicianEvaluationEntity>)info.GetValue("_physicianEvaluation", typeof(EntityCollection<PhysicianEvaluationEntity>));
				_physicianEventAssignment_ = (EntityCollection<PhysicianEventAssignmentEntity>)info.GetValue("_physicianEventAssignment_", typeof(EntityCollection<PhysicianEventAssignmentEntity>));
				_physicianEventAssignment = (EntityCollection<PhysicianEventAssignmentEntity>)info.GetValue("_physicianEventAssignment", typeof(EntityCollection<PhysicianEventAssignmentEntity>));
				_physicianInvoice = (EntityCollection<PhysicianInvoiceEntity>)info.GetValue("_physicianInvoice", typeof(EntityCollection<PhysicianInvoiceEntity>));
				_physicianLabTest = (EntityCollection<PhysicianLabTestEntity>)info.GetValue("_physicianLabTest", typeof(EntityCollection<PhysicianLabTestEntity>));
				_physicianLicense = (EntityCollection<PhysicianLicenseEntity>)info.GetValue("_physicianLicense", typeof(EntityCollection<PhysicianLicenseEntity>));
				_physicianPermittedTest = (EntityCollection<PhysicianPermittedTestEntity>)info.GetValue("_physicianPermittedTest", typeof(EntityCollection<PhysicianPermittedTestEntity>));
				_physicianPod = (EntityCollection<PhysicianPodEntity>)info.GetValue("_physicianPod", typeof(EntityCollection<PhysicianPodEntity>));
				_screeningAuthorization = (EntityCollection<ScreeningAuthorizationEntity>)info.GetValue("_screeningAuthorization", typeof(EntityCollection<ScreeningAuthorizationEntity>));
				_eventCustomersCollectionViaPhysicianEvaluation = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaPhysicianEvaluation", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaPhysicianCustomerAssignment_ = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaPhysicianCustomerAssignment_", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaPhysicianCustomerAssignment = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaPhysicianCustomerAssignment", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaPhysicianEventAssignment_ = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaPhysicianEventAssignment_", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaPhysicianEventAssignment = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaPhysicianEventAssignment", typeof(EntityCollection<EventsEntity>));
				_physicianEvaluationCollectionViaPhysicianEarnings = (EntityCollection<PhysicianEvaluationEntity>)info.GetValue("_physicianEvaluationCollectionViaPhysicianEarnings", typeof(EntityCollection<PhysicianEvaluationEntity>));
				_podDetailsCollectionViaPhysicianPod = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaPhysicianPod", typeof(EntityCollection<PodDetailsEntity>));
				_stateCollectionViaPhysicianLicense = (EntityCollection<StateEntity>)info.GetValue("_stateCollectionViaPhysicianLicense", typeof(EntityCollection<StateEntity>));
				_stateCollectionViaPhysicianLabTest = (EntityCollection<StateEntity>)info.GetValue("_stateCollectionViaPhysicianLabTest", typeof(EntityCollection<StateEntity>));
				_testCollectionViaPhysicianPermittedTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaPhysicianPermittedTest", typeof(EntityCollection<TestEntity>));
				_file_ = (FileEntity)info.GetValue("_file_", typeof(FileEntity));
				if(_file_!=null)
				{
					_file_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file = (FileEntity)info.GetValue("_file", typeof(FileEntity));
				if(_file!=null)
				{
					_file.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_mvuserClassification = (MvuserClassificationEntity)info.GetValue("_mvuserClassification", typeof(MvuserClassificationEntity));
				if(_mvuserClassification!=null)
				{
					_mvuserClassification.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_physicianSpecialization = (PhysicianSpecializationEntity)info.GetValue("_physicianSpecialization", typeof(PhysicianSpecializationEntity));
				if(_physicianSpecialization!=null)
				{
					_physicianSpecialization.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_physicianCustomerPayRate = (PhysicianCustomerPayRateEntity)info.GetValue("_physicianCustomerPayRate", typeof(PhysicianCustomerPayRateEntity));
				if(_physicianCustomerPayRate!=null)
				{
					_physicianCustomerPayRate.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PhysicianProfileFieldIndex)fieldIndex)
			{
				case PhysicianProfileFieldIndex.PhysicianId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case PhysicianProfileFieldIndex.ResumeFileId:
					DesetupSyncFile(true, false);
					break;
				case PhysicianProfileFieldIndex.DigitalSignatureFileId:
					DesetupSyncFile_(true, false);
					break;
				case PhysicianProfileFieldIndex.SpecializationId:
					DesetupSyncPhysicianSpecialization(true, false);
					break;
				case PhysicianProfileFieldIndex.ClassificationId:
					DesetupSyncMvuserClassification(true, false);
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
				case "File_":
					this.File_ = (FileEntity)entity;
					break;
				case "File":
					this.File = (FileEntity)entity;
					break;
				case "MvuserClassification":
					this.MvuserClassification = (MvuserClassificationEntity)entity;
					break;
				case "PhysicianSpecialization":
					this.PhysicianSpecialization = (PhysicianSpecializationEntity)entity;
					break;
				case "CustomerSkipReview":
					this.CustomerSkipReview.Add((CustomerSkipReviewEntity)entity);
					break;
				case "EventCustomerEvaluationLock":
					this.EventCustomerEvaluationLock.Add((EventCustomerEvaluationLockEntity)entity);
					break;
				case "PhysicianCustomerAssignment_":
					this.PhysicianCustomerAssignment_.Add((PhysicianCustomerAssignmentEntity)entity);
					break;
				case "PhysicianCustomerAssignment":
					this.PhysicianCustomerAssignment.Add((PhysicianCustomerAssignmentEntity)entity);
					break;
				case "PhysicianEarnings":
					this.PhysicianEarnings.Add((PhysicianEarningsEntity)entity);
					break;
				case "PhysicianEvaluation":
					this.PhysicianEvaluation.Add((PhysicianEvaluationEntity)entity);
					break;
				case "PhysicianEventAssignment_":
					this.PhysicianEventAssignment_.Add((PhysicianEventAssignmentEntity)entity);
					break;
				case "PhysicianEventAssignment":
					this.PhysicianEventAssignment.Add((PhysicianEventAssignmentEntity)entity);
					break;
				case "PhysicianInvoice":
					this.PhysicianInvoice.Add((PhysicianInvoiceEntity)entity);
					break;
				case "PhysicianLabTest":
					this.PhysicianLabTest.Add((PhysicianLabTestEntity)entity);
					break;
				case "PhysicianLicense":
					this.PhysicianLicense.Add((PhysicianLicenseEntity)entity);
					break;
				case "PhysicianPermittedTest":
					this.PhysicianPermittedTest.Add((PhysicianPermittedTestEntity)entity);
					break;
				case "PhysicianPod":
					this.PhysicianPod.Add((PhysicianPodEntity)entity);
					break;
				case "ScreeningAuthorization":
					this.ScreeningAuthorization.Add((ScreeningAuthorizationEntity)entity);
					break;
				case "EventCustomersCollectionViaPhysicianEvaluation":
					this.EventCustomersCollectionViaPhysicianEvaluation.IsReadOnly = false;
					this.EventCustomersCollectionViaPhysicianEvaluation.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaPhysicianEvaluation.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaPhysicianCustomerAssignment_":
					this.EventCustomersCollectionViaPhysicianCustomerAssignment_.IsReadOnly = false;
					this.EventCustomersCollectionViaPhysicianCustomerAssignment_.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaPhysicianCustomerAssignment_.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaPhysicianCustomerAssignment":
					this.EventCustomersCollectionViaPhysicianCustomerAssignment.IsReadOnly = false;
					this.EventCustomersCollectionViaPhysicianCustomerAssignment.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaPhysicianCustomerAssignment.IsReadOnly = true;
					break;
				case "EventsCollectionViaPhysicianEventAssignment_":
					this.EventsCollectionViaPhysicianEventAssignment_.IsReadOnly = false;
					this.EventsCollectionViaPhysicianEventAssignment_.Add((EventsEntity)entity);
					this.EventsCollectionViaPhysicianEventAssignment_.IsReadOnly = true;
					break;
				case "EventsCollectionViaPhysicianEventAssignment":
					this.EventsCollectionViaPhysicianEventAssignment.IsReadOnly = false;
					this.EventsCollectionViaPhysicianEventAssignment.Add((EventsEntity)entity);
					this.EventsCollectionViaPhysicianEventAssignment.IsReadOnly = true;
					break;
				case "PhysicianEvaluationCollectionViaPhysicianEarnings":
					this.PhysicianEvaluationCollectionViaPhysicianEarnings.IsReadOnly = false;
					this.PhysicianEvaluationCollectionViaPhysicianEarnings.Add((PhysicianEvaluationEntity)entity);
					this.PhysicianEvaluationCollectionViaPhysicianEarnings.IsReadOnly = true;
					break;
				case "PodDetailsCollectionViaPhysicianPod":
					this.PodDetailsCollectionViaPhysicianPod.IsReadOnly = false;
					this.PodDetailsCollectionViaPhysicianPod.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaPhysicianPod.IsReadOnly = true;
					break;
				case "StateCollectionViaPhysicianLicense":
					this.StateCollectionViaPhysicianLicense.IsReadOnly = false;
					this.StateCollectionViaPhysicianLicense.Add((StateEntity)entity);
					this.StateCollectionViaPhysicianLicense.IsReadOnly = true;
					break;
				case "StateCollectionViaPhysicianLabTest":
					this.StateCollectionViaPhysicianLabTest.IsReadOnly = false;
					this.StateCollectionViaPhysicianLabTest.Add((StateEntity)entity);
					this.StateCollectionViaPhysicianLabTest.IsReadOnly = true;
					break;
				case "TestCollectionViaPhysicianPermittedTest":
					this.TestCollectionViaPhysicianPermittedTest.IsReadOnly = false;
					this.TestCollectionViaPhysicianPermittedTest.Add((TestEntity)entity);
					this.TestCollectionViaPhysicianPermittedTest.IsReadOnly = true;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "PhysicianCustomerPayRate":
					this.PhysicianCustomerPayRate = (PhysicianCustomerPayRateEntity)entity;
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
			return PhysicianProfileEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "File_":
					toReturn.Add(PhysicianProfileEntity.Relations.FileEntityUsingDigitalSignatureFileId);
					break;
				case "File":
					toReturn.Add(PhysicianProfileEntity.Relations.FileEntityUsingResumeFileId);
					break;
				case "MvuserClassification":
					toReturn.Add(PhysicianProfileEntity.Relations.MvuserClassificationEntityUsingClassificationId);
					break;
				case "PhysicianSpecialization":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianSpecializationEntityUsingSpecializationId);
					break;
				case "CustomerSkipReview":
					toReturn.Add(PhysicianProfileEntity.Relations.CustomerSkipReviewEntityUsingDefaultPhysicianId);
					break;
				case "EventCustomerEvaluationLock":
					toReturn.Add(PhysicianProfileEntity.Relations.EventCustomerEvaluationLockEntityUsingPhysicianId);
					break;
				case "PhysicianCustomerAssignment_":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianCustomerAssignmentEntityUsingPhysicianId);
					break;
				case "PhysicianCustomerAssignment":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianCustomerAssignmentEntityUsingOverReadPhysicianId);
					break;
				case "PhysicianEarnings":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianEarningsEntityUsingPhysicianId);
					break;
				case "PhysicianEvaluation":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianEvaluationEntityUsingPhysicianId);
					break;
				case "PhysicianEventAssignment_":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianEventAssignmentEntityUsingPhysicianId);
					break;
				case "PhysicianEventAssignment":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianEventAssignmentEntityUsingOverReadPhysicianId);
					break;
				case "PhysicianInvoice":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianInvoiceEntityUsingPhysicianId);
					break;
				case "PhysicianLabTest":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianLabTestEntityUsingPhysicianId);
					break;
				case "PhysicianLicense":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianLicenseEntityUsingPhysicianId);
					break;
				case "PhysicianPermittedTest":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianPermittedTestEntityUsingOrganizationRoleUserId);
					break;
				case "PhysicianPod":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianPodEntityUsingPhysicianId);
					break;
				case "ScreeningAuthorization":
					toReturn.Add(PhysicianProfileEntity.Relations.ScreeningAuthorizationEntityUsingPhysicianOrgRoleUserId);
					break;
				case "EventCustomersCollectionViaPhysicianEvaluation":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianEvaluationEntityUsingPhysicianId, "PhysicianProfileEntity__", "PhysicianEvaluation_", JoinHint.None);
					toReturn.Add(PhysicianEvaluationEntity.Relations.EventCustomersEntityUsingEventCustomerId, "PhysicianEvaluation_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaPhysicianCustomerAssignment_":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianCustomerAssignmentEntityUsingPhysicianId, "PhysicianProfileEntity__", "PhysicianCustomerAssignment_", JoinHint.None);
					toReturn.Add(PhysicianCustomerAssignmentEntity.Relations.EventCustomersEntityUsingEventCustomerId, "PhysicianCustomerAssignment_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaPhysicianCustomerAssignment":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianCustomerAssignmentEntityUsingOverReadPhysicianId, "PhysicianProfileEntity__", "PhysicianCustomerAssignment_", JoinHint.None);
					toReturn.Add(PhysicianCustomerAssignmentEntity.Relations.EventCustomersEntityUsingEventCustomerId, "PhysicianCustomerAssignment_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaPhysicianEventAssignment_":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianEventAssignmentEntityUsingPhysicianId, "PhysicianProfileEntity__", "PhysicianEventAssignment_", JoinHint.None);
					toReturn.Add(PhysicianEventAssignmentEntity.Relations.EventsEntityUsingEventId, "PhysicianEventAssignment_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaPhysicianEventAssignment":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianEventAssignmentEntityUsingOverReadPhysicianId, "PhysicianProfileEntity__", "PhysicianEventAssignment_", JoinHint.None);
					toReturn.Add(PhysicianEventAssignmentEntity.Relations.EventsEntityUsingEventId, "PhysicianEventAssignment_", string.Empty, JoinHint.None);
					break;
				case "PhysicianEvaluationCollectionViaPhysicianEarnings":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianEarningsEntityUsingPhysicianId, "PhysicianProfileEntity__", "PhysicianEarnings_", JoinHint.None);
					toReturn.Add(PhysicianEarningsEntity.Relations.PhysicianEvaluationEntityUsingPhysicianEvaluationId, "PhysicianEarnings_", string.Empty, JoinHint.None);
					break;
				case "PodDetailsCollectionViaPhysicianPod":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianPodEntityUsingPhysicianId, "PhysicianProfileEntity__", "PhysicianPod_", JoinHint.None);
					toReturn.Add(PhysicianPodEntity.Relations.PodDetailsEntityUsingPodId, "PhysicianPod_", string.Empty, JoinHint.None);
					break;
				case "StateCollectionViaPhysicianLicense":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianLicenseEntityUsingPhysicianId, "PhysicianProfileEntity__", "PhysicianLicense_", JoinHint.None);
					toReturn.Add(PhysicianLicenseEntity.Relations.StateEntityUsingStateId, "PhysicianLicense_", string.Empty, JoinHint.None);
					break;
				case "StateCollectionViaPhysicianLabTest":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianLabTestEntityUsingPhysicianId, "PhysicianProfileEntity__", "PhysicianLabTest_", JoinHint.None);
					toReturn.Add(PhysicianLabTestEntity.Relations.StateEntityUsingStateId, "PhysicianLabTest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaPhysicianPermittedTest":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianPermittedTestEntityUsingOrganizationRoleUserId, "PhysicianProfileEntity__", "PhysicianPermittedTest_", JoinHint.None);
					toReturn.Add(PhysicianPermittedTestEntity.Relations.TestEntityUsingTestId, "PhysicianPermittedTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(PhysicianProfileEntity.Relations.OrganizationRoleUserEntityUsingPhysicianId);
					break;
				case "PhysicianCustomerPayRate":
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianCustomerPayRateEntityUsingPhysicianId);
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
				case "File_":
					SetupSyncFile_(relatedEntity);
					break;
				case "File":
					SetupSyncFile(relatedEntity);
					break;
				case "MvuserClassification":
					SetupSyncMvuserClassification(relatedEntity);
					break;
				case "PhysicianSpecialization":
					SetupSyncPhysicianSpecialization(relatedEntity);
					break;
				case "CustomerSkipReview":
					this.CustomerSkipReview.Add((CustomerSkipReviewEntity)relatedEntity);
					break;
				case "EventCustomerEvaluationLock":
					this.EventCustomerEvaluationLock.Add((EventCustomerEvaluationLockEntity)relatedEntity);
					break;
				case "PhysicianCustomerAssignment_":
					this.PhysicianCustomerAssignment_.Add((PhysicianCustomerAssignmentEntity)relatedEntity);
					break;
				case "PhysicianCustomerAssignment":
					this.PhysicianCustomerAssignment.Add((PhysicianCustomerAssignmentEntity)relatedEntity);
					break;
				case "PhysicianEarnings":
					this.PhysicianEarnings.Add((PhysicianEarningsEntity)relatedEntity);
					break;
				case "PhysicianEvaluation":
					this.PhysicianEvaluation.Add((PhysicianEvaluationEntity)relatedEntity);
					break;
				case "PhysicianEventAssignment_":
					this.PhysicianEventAssignment_.Add((PhysicianEventAssignmentEntity)relatedEntity);
					break;
				case "PhysicianEventAssignment":
					this.PhysicianEventAssignment.Add((PhysicianEventAssignmentEntity)relatedEntity);
					break;
				case "PhysicianInvoice":
					this.PhysicianInvoice.Add((PhysicianInvoiceEntity)relatedEntity);
					break;
				case "PhysicianLabTest":
					this.PhysicianLabTest.Add((PhysicianLabTestEntity)relatedEntity);
					break;
				case "PhysicianLicense":
					this.PhysicianLicense.Add((PhysicianLicenseEntity)relatedEntity);
					break;
				case "PhysicianPermittedTest":
					this.PhysicianPermittedTest.Add((PhysicianPermittedTestEntity)relatedEntity);
					break;
				case "PhysicianPod":
					this.PhysicianPod.Add((PhysicianPodEntity)relatedEntity);
					break;
				case "ScreeningAuthorization":
					this.ScreeningAuthorization.Add((ScreeningAuthorizationEntity)relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "PhysicianCustomerPayRate":
					SetupSyncPhysicianCustomerPayRate(relatedEntity);
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
				case "File_":
					DesetupSyncFile_(false, true);
					break;
				case "File":
					DesetupSyncFile(false, true);
					break;
				case "MvuserClassification":
					DesetupSyncMvuserClassification(false, true);
					break;
				case "PhysicianSpecialization":
					DesetupSyncPhysicianSpecialization(false, true);
					break;
				case "CustomerSkipReview":
					base.PerformRelatedEntityRemoval(this.CustomerSkipReview, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerEvaluationLock":
					base.PerformRelatedEntityRemoval(this.EventCustomerEvaluationLock, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianCustomerAssignment_":
					base.PerformRelatedEntityRemoval(this.PhysicianCustomerAssignment_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianCustomerAssignment":
					base.PerformRelatedEntityRemoval(this.PhysicianCustomerAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianEarnings":
					base.PerformRelatedEntityRemoval(this.PhysicianEarnings, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianEvaluation":
					base.PerformRelatedEntityRemoval(this.PhysicianEvaluation, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianEventAssignment_":
					base.PerformRelatedEntityRemoval(this.PhysicianEventAssignment_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianEventAssignment":
					base.PerformRelatedEntityRemoval(this.PhysicianEventAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianInvoice":
					base.PerformRelatedEntityRemoval(this.PhysicianInvoice, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianLabTest":
					base.PerformRelatedEntityRemoval(this.PhysicianLabTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianLicense":
					base.PerformRelatedEntityRemoval(this.PhysicianLicense, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianPermittedTest":
					base.PerformRelatedEntityRemoval(this.PhysicianPermittedTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianPod":
					base.PerformRelatedEntityRemoval(this.PhysicianPod, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ScreeningAuthorization":
					base.PerformRelatedEntityRemoval(this.ScreeningAuthorization, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "PhysicianCustomerPayRate":
					DesetupSyncPhysicianCustomerPayRate(false, true);
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


			if(_physicianCustomerPayRate!=null)
			{
				toReturn.Add(_physicianCustomerPayRate);
			}

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_file_!=null)
			{
				toReturn.Add(_file_);
			}
			if(_file!=null)
			{
				toReturn.Add(_file);
			}
			if(_mvuserClassification!=null)
			{
				toReturn.Add(_mvuserClassification);
			}
			if(_physicianSpecialization!=null)
			{
				toReturn.Add(_physicianSpecialization);
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
			toReturn.Add(this.CustomerSkipReview);
			toReturn.Add(this.EventCustomerEvaluationLock);
			toReturn.Add(this.PhysicianCustomerAssignment_);
			toReturn.Add(this.PhysicianCustomerAssignment);
			toReturn.Add(this.PhysicianEarnings);
			toReturn.Add(this.PhysicianEvaluation);
			toReturn.Add(this.PhysicianEventAssignment_);
			toReturn.Add(this.PhysicianEventAssignment);
			toReturn.Add(this.PhysicianInvoice);
			toReturn.Add(this.PhysicianLabTest);
			toReturn.Add(this.PhysicianLicense);
			toReturn.Add(this.PhysicianPermittedTest);
			toReturn.Add(this.PhysicianPod);
			toReturn.Add(this.ScreeningAuthorization);

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
				info.AddValue("_customerSkipReview", ((_customerSkipReview!=null) && (_customerSkipReview.Count>0) && !this.MarkedForDeletion)?_customerSkipReview:null);
				info.AddValue("_eventCustomerEvaluationLock", ((_eventCustomerEvaluationLock!=null) && (_eventCustomerEvaluationLock.Count>0) && !this.MarkedForDeletion)?_eventCustomerEvaluationLock:null);
				info.AddValue("_physicianCustomerAssignment_", ((_physicianCustomerAssignment_!=null) && (_physicianCustomerAssignment_.Count>0) && !this.MarkedForDeletion)?_physicianCustomerAssignment_:null);
				info.AddValue("_physicianCustomerAssignment", ((_physicianCustomerAssignment!=null) && (_physicianCustomerAssignment.Count>0) && !this.MarkedForDeletion)?_physicianCustomerAssignment:null);
				info.AddValue("_physicianEarnings", ((_physicianEarnings!=null) && (_physicianEarnings.Count>0) && !this.MarkedForDeletion)?_physicianEarnings:null);
				info.AddValue("_physicianEvaluation", ((_physicianEvaluation!=null) && (_physicianEvaluation.Count>0) && !this.MarkedForDeletion)?_physicianEvaluation:null);
				info.AddValue("_physicianEventAssignment_", ((_physicianEventAssignment_!=null) && (_physicianEventAssignment_.Count>0) && !this.MarkedForDeletion)?_physicianEventAssignment_:null);
				info.AddValue("_physicianEventAssignment", ((_physicianEventAssignment!=null) && (_physicianEventAssignment.Count>0) && !this.MarkedForDeletion)?_physicianEventAssignment:null);
				info.AddValue("_physicianInvoice", ((_physicianInvoice!=null) && (_physicianInvoice.Count>0) && !this.MarkedForDeletion)?_physicianInvoice:null);
				info.AddValue("_physicianLabTest", ((_physicianLabTest!=null) && (_physicianLabTest.Count>0) && !this.MarkedForDeletion)?_physicianLabTest:null);
				info.AddValue("_physicianLicense", ((_physicianLicense!=null) && (_physicianLicense.Count>0) && !this.MarkedForDeletion)?_physicianLicense:null);
				info.AddValue("_physicianPermittedTest", ((_physicianPermittedTest!=null) && (_physicianPermittedTest.Count>0) && !this.MarkedForDeletion)?_physicianPermittedTest:null);
				info.AddValue("_physicianPod", ((_physicianPod!=null) && (_physicianPod.Count>0) && !this.MarkedForDeletion)?_physicianPod:null);
				info.AddValue("_screeningAuthorization", ((_screeningAuthorization!=null) && (_screeningAuthorization.Count>0) && !this.MarkedForDeletion)?_screeningAuthorization:null);
				info.AddValue("_eventCustomersCollectionViaPhysicianEvaluation", ((_eventCustomersCollectionViaPhysicianEvaluation!=null) && (_eventCustomersCollectionViaPhysicianEvaluation.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaPhysicianEvaluation:null);
				info.AddValue("_eventCustomersCollectionViaPhysicianCustomerAssignment_", ((_eventCustomersCollectionViaPhysicianCustomerAssignment_!=null) && (_eventCustomersCollectionViaPhysicianCustomerAssignment_.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaPhysicianCustomerAssignment_:null);
				info.AddValue("_eventCustomersCollectionViaPhysicianCustomerAssignment", ((_eventCustomersCollectionViaPhysicianCustomerAssignment!=null) && (_eventCustomersCollectionViaPhysicianCustomerAssignment.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaPhysicianCustomerAssignment:null);
				info.AddValue("_eventsCollectionViaPhysicianEventAssignment_", ((_eventsCollectionViaPhysicianEventAssignment_!=null) && (_eventsCollectionViaPhysicianEventAssignment_.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaPhysicianEventAssignment_:null);
				info.AddValue("_eventsCollectionViaPhysicianEventAssignment", ((_eventsCollectionViaPhysicianEventAssignment!=null) && (_eventsCollectionViaPhysicianEventAssignment.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaPhysicianEventAssignment:null);
				info.AddValue("_physicianEvaluationCollectionViaPhysicianEarnings", ((_physicianEvaluationCollectionViaPhysicianEarnings!=null) && (_physicianEvaluationCollectionViaPhysicianEarnings.Count>0) && !this.MarkedForDeletion)?_physicianEvaluationCollectionViaPhysicianEarnings:null);
				info.AddValue("_podDetailsCollectionViaPhysicianPod", ((_podDetailsCollectionViaPhysicianPod!=null) && (_podDetailsCollectionViaPhysicianPod.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaPhysicianPod:null);
				info.AddValue("_stateCollectionViaPhysicianLicense", ((_stateCollectionViaPhysicianLicense!=null) && (_stateCollectionViaPhysicianLicense.Count>0) && !this.MarkedForDeletion)?_stateCollectionViaPhysicianLicense:null);
				info.AddValue("_stateCollectionViaPhysicianLabTest", ((_stateCollectionViaPhysicianLabTest!=null) && (_stateCollectionViaPhysicianLabTest.Count>0) && !this.MarkedForDeletion)?_stateCollectionViaPhysicianLabTest:null);
				info.AddValue("_testCollectionViaPhysicianPermittedTest", ((_testCollectionViaPhysicianPermittedTest!=null) && (_testCollectionViaPhysicianPermittedTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaPhysicianPermittedTest:null);
				info.AddValue("_file_", (!this.MarkedForDeletion?_file_:null));
				info.AddValue("_file", (!this.MarkedForDeletion?_file:null));
				info.AddValue("_mvuserClassification", (!this.MarkedForDeletion?_mvuserClassification:null));
				info.AddValue("_physicianSpecialization", (!this.MarkedForDeletion?_physicianSpecialization:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_physicianCustomerPayRate", (!this.MarkedForDeletion?_physicianCustomerPayRate:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PhysicianProfileFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PhysicianProfileFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PhysicianProfileRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerSkipReview' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerSkipReview()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerSkipReviewFields.DefaultPhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerEvaluationLock' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerEvaluationLock()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerEvaluationLockFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianCustomerAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianCustomerAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianCustomerAssignmentFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianCustomerAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianCustomerAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianCustomerAssignmentFields.OverReadPhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianEarnings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianEarnings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEarningsFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianEvaluation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianEvaluation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEvaluationFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianEventAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianEventAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEventAssignmentFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianEventAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianEventAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEventAssignmentFields.OverReadPhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianInvoice' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianInvoice()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianInvoiceFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianLabTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianLabTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianLabTestFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianLicense' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianLicense()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianLicenseFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianPermittedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianPermittedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianPermittedTestFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianPod' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianPodFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ScreeningAuthorization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScreeningAuthorization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScreeningAuthorizationFields.PhysicianOrgRoleUserId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaPhysicianEvaluation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaPhysicianEvaluation"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaPhysicianCustomerAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaPhysicianCustomerAssignment_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaPhysicianCustomerAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaPhysicianCustomerAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaPhysicianEventAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaPhysicianEventAssignment_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaPhysicianEventAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaPhysicianEventAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianEvaluation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianEvaluationCollectionViaPhysicianEarnings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianEvaluationCollectionViaPhysicianEarnings"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaPhysicianPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaPhysicianPod"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'State' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStateCollectionViaPhysicianLicense()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StateCollectionViaPhysicianLicense"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'State' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStateCollectionViaPhysicianLabTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StateCollectionViaPhysicianLabTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaPhysicianPermittedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaPhysicianPermittedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId, "PhysicianProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.DigitalSignatureFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.ResumeFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MvuserClassification' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvuserClassification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvuserClassificationFields.MvuserClassificationId, null, ComparisonOperator.Equal, this.ClassificationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PhysicianSpecialization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianSpecialization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianSpecializationFields.PhysicianSpecializationId, null, ComparisonOperator.Equal, this.SpecializationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PhysicianCustomerPayRate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianCustomerPayRate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianCustomerPayRateFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PhysicianProfileEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerSkipReview);
			collectionsQueue.Enqueue(this._eventCustomerEvaluationLock);
			collectionsQueue.Enqueue(this._physicianCustomerAssignment_);
			collectionsQueue.Enqueue(this._physicianCustomerAssignment);
			collectionsQueue.Enqueue(this._physicianEarnings);
			collectionsQueue.Enqueue(this._physicianEvaluation);
			collectionsQueue.Enqueue(this._physicianEventAssignment_);
			collectionsQueue.Enqueue(this._physicianEventAssignment);
			collectionsQueue.Enqueue(this._physicianInvoice);
			collectionsQueue.Enqueue(this._physicianLabTest);
			collectionsQueue.Enqueue(this._physicianLicense);
			collectionsQueue.Enqueue(this._physicianPermittedTest);
			collectionsQueue.Enqueue(this._physicianPod);
			collectionsQueue.Enqueue(this._screeningAuthorization);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaPhysicianEvaluation);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaPhysicianCustomerAssignment_);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaPhysicianCustomerAssignment);
			collectionsQueue.Enqueue(this._eventsCollectionViaPhysicianEventAssignment_);
			collectionsQueue.Enqueue(this._eventsCollectionViaPhysicianEventAssignment);
			collectionsQueue.Enqueue(this._physicianEvaluationCollectionViaPhysicianEarnings);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaPhysicianPod);
			collectionsQueue.Enqueue(this._stateCollectionViaPhysicianLicense);
			collectionsQueue.Enqueue(this._stateCollectionViaPhysicianLabTest);
			collectionsQueue.Enqueue(this._testCollectionViaPhysicianPermittedTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerSkipReview = (EntityCollection<CustomerSkipReviewEntity>) collectionsQueue.Dequeue();
			this._eventCustomerEvaluationLock = (EntityCollection<EventCustomerEvaluationLockEntity>) collectionsQueue.Dequeue();
			this._physicianCustomerAssignment_ = (EntityCollection<PhysicianCustomerAssignmentEntity>) collectionsQueue.Dequeue();
			this._physicianCustomerAssignment = (EntityCollection<PhysicianCustomerAssignmentEntity>) collectionsQueue.Dequeue();
			this._physicianEarnings = (EntityCollection<PhysicianEarningsEntity>) collectionsQueue.Dequeue();
			this._physicianEvaluation = (EntityCollection<PhysicianEvaluationEntity>) collectionsQueue.Dequeue();
			this._physicianEventAssignment_ = (EntityCollection<PhysicianEventAssignmentEntity>) collectionsQueue.Dequeue();
			this._physicianEventAssignment = (EntityCollection<PhysicianEventAssignmentEntity>) collectionsQueue.Dequeue();
			this._physicianInvoice = (EntityCollection<PhysicianInvoiceEntity>) collectionsQueue.Dequeue();
			this._physicianLabTest = (EntityCollection<PhysicianLabTestEntity>) collectionsQueue.Dequeue();
			this._physicianLicense = (EntityCollection<PhysicianLicenseEntity>) collectionsQueue.Dequeue();
			this._physicianPermittedTest = (EntityCollection<PhysicianPermittedTestEntity>) collectionsQueue.Dequeue();
			this._physicianPod = (EntityCollection<PhysicianPodEntity>) collectionsQueue.Dequeue();
			this._screeningAuthorization = (EntityCollection<ScreeningAuthorizationEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaPhysicianEvaluation = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaPhysicianCustomerAssignment_ = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaPhysicianCustomerAssignment = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaPhysicianEventAssignment_ = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaPhysicianEventAssignment = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._physicianEvaluationCollectionViaPhysicianEarnings = (EntityCollection<PhysicianEvaluationEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaPhysicianPod = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
			this._stateCollectionViaPhysicianLicense = (EntityCollection<StateEntity>) collectionsQueue.Dequeue();
			this._stateCollectionViaPhysicianLabTest = (EntityCollection<StateEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaPhysicianPermittedTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerSkipReview != null)
			{
				return true;
			}
			if (this._eventCustomerEvaluationLock != null)
			{
				return true;
			}
			if (this._physicianCustomerAssignment_ != null)
			{
				return true;
			}
			if (this._physicianCustomerAssignment != null)
			{
				return true;
			}
			if (this._physicianEarnings != null)
			{
				return true;
			}
			if (this._physicianEvaluation != null)
			{
				return true;
			}
			if (this._physicianEventAssignment_ != null)
			{
				return true;
			}
			if (this._physicianEventAssignment != null)
			{
				return true;
			}
			if (this._physicianInvoice != null)
			{
				return true;
			}
			if (this._physicianLabTest != null)
			{
				return true;
			}
			if (this._physicianLicense != null)
			{
				return true;
			}
			if (this._physicianPermittedTest != null)
			{
				return true;
			}
			if (this._physicianPod != null)
			{
				return true;
			}
			if (this._screeningAuthorization != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaPhysicianEvaluation != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaPhysicianCustomerAssignment_ != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaPhysicianCustomerAssignment != null)
			{
				return true;
			}
			if (this._eventsCollectionViaPhysicianEventAssignment_ != null)
			{
				return true;
			}
			if (this._eventsCollectionViaPhysicianEventAssignment != null)
			{
				return true;
			}
			if (this._physicianEvaluationCollectionViaPhysicianEarnings != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaPhysicianPod != null)
			{
				return true;
			}
			if (this._stateCollectionViaPhysicianLicense != null)
			{
				return true;
			}
			if (this._stateCollectionViaPhysicianLabTest != null)
			{
				return true;
			}
			if (this._testCollectionViaPhysicianPermittedTest != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerSkipReviewEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerSkipReviewEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerEvaluationLockEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEvaluationLockEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianCustomerAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianCustomerAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianEarningsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEarningsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianEventAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEventAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianEventAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEventAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianLabTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLabTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianLicenseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLicenseEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianPermittedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPermittedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPodEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ScreeningAuthorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScreeningAuthorizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))) : null);
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
			toReturn.Add("File_", _file_);
			toReturn.Add("File", _file);
			toReturn.Add("MvuserClassification", _mvuserClassification);
			toReturn.Add("PhysicianSpecialization", _physicianSpecialization);
			toReturn.Add("CustomerSkipReview", _customerSkipReview);
			toReturn.Add("EventCustomerEvaluationLock", _eventCustomerEvaluationLock);
			toReturn.Add("PhysicianCustomerAssignment_", _physicianCustomerAssignment_);
			toReturn.Add("PhysicianCustomerAssignment", _physicianCustomerAssignment);
			toReturn.Add("PhysicianEarnings", _physicianEarnings);
			toReturn.Add("PhysicianEvaluation", _physicianEvaluation);
			toReturn.Add("PhysicianEventAssignment_", _physicianEventAssignment_);
			toReturn.Add("PhysicianEventAssignment", _physicianEventAssignment);
			toReturn.Add("PhysicianInvoice", _physicianInvoice);
			toReturn.Add("PhysicianLabTest", _physicianLabTest);
			toReturn.Add("PhysicianLicense", _physicianLicense);
			toReturn.Add("PhysicianPermittedTest", _physicianPermittedTest);
			toReturn.Add("PhysicianPod", _physicianPod);
			toReturn.Add("ScreeningAuthorization", _screeningAuthorization);
			toReturn.Add("EventCustomersCollectionViaPhysicianEvaluation", _eventCustomersCollectionViaPhysicianEvaluation);
			toReturn.Add("EventCustomersCollectionViaPhysicianCustomerAssignment_", _eventCustomersCollectionViaPhysicianCustomerAssignment_);
			toReturn.Add("EventCustomersCollectionViaPhysicianCustomerAssignment", _eventCustomersCollectionViaPhysicianCustomerAssignment);
			toReturn.Add("EventsCollectionViaPhysicianEventAssignment_", _eventsCollectionViaPhysicianEventAssignment_);
			toReturn.Add("EventsCollectionViaPhysicianEventAssignment", _eventsCollectionViaPhysicianEventAssignment);
			toReturn.Add("PhysicianEvaluationCollectionViaPhysicianEarnings", _physicianEvaluationCollectionViaPhysicianEarnings);
			toReturn.Add("PodDetailsCollectionViaPhysicianPod", _podDetailsCollectionViaPhysicianPod);
			toReturn.Add("StateCollectionViaPhysicianLicense", _stateCollectionViaPhysicianLicense);
			toReturn.Add("StateCollectionViaPhysicianLabTest", _stateCollectionViaPhysicianLabTest);
			toReturn.Add("TestCollectionViaPhysicianPermittedTest", _testCollectionViaPhysicianPermittedTest);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("PhysicianCustomerPayRate", _physicianCustomerPayRate);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerSkipReview!=null)
			{
				_customerSkipReview.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerEvaluationLock!=null)
			{
				_eventCustomerEvaluationLock.ActiveContext = base.ActiveContext;
			}
			if(_physicianCustomerAssignment_!=null)
			{
				_physicianCustomerAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_physicianCustomerAssignment!=null)
			{
				_physicianCustomerAssignment.ActiveContext = base.ActiveContext;
			}
			if(_physicianEarnings!=null)
			{
				_physicianEarnings.ActiveContext = base.ActiveContext;
			}
			if(_physicianEvaluation!=null)
			{
				_physicianEvaluation.ActiveContext = base.ActiveContext;
			}
			if(_physicianEventAssignment_!=null)
			{
				_physicianEventAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_physicianEventAssignment!=null)
			{
				_physicianEventAssignment.ActiveContext = base.ActiveContext;
			}
			if(_physicianInvoice!=null)
			{
				_physicianInvoice.ActiveContext = base.ActiveContext;
			}
			if(_physicianLabTest!=null)
			{
				_physicianLabTest.ActiveContext = base.ActiveContext;
			}
			if(_physicianLicense!=null)
			{
				_physicianLicense.ActiveContext = base.ActiveContext;
			}
			if(_physicianPermittedTest!=null)
			{
				_physicianPermittedTest.ActiveContext = base.ActiveContext;
			}
			if(_physicianPod!=null)
			{
				_physicianPod.ActiveContext = base.ActiveContext;
			}
			if(_screeningAuthorization!=null)
			{
				_screeningAuthorization.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaPhysicianEvaluation!=null)
			{
				_eventCustomersCollectionViaPhysicianEvaluation.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaPhysicianCustomerAssignment_!=null)
			{
				_eventCustomersCollectionViaPhysicianCustomerAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaPhysicianCustomerAssignment!=null)
			{
				_eventCustomersCollectionViaPhysicianCustomerAssignment.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaPhysicianEventAssignment_!=null)
			{
				_eventsCollectionViaPhysicianEventAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaPhysicianEventAssignment!=null)
			{
				_eventsCollectionViaPhysicianEventAssignment.ActiveContext = base.ActiveContext;
			}
			if(_physicianEvaluationCollectionViaPhysicianEarnings!=null)
			{
				_physicianEvaluationCollectionViaPhysicianEarnings.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaPhysicianPod!=null)
			{
				_podDetailsCollectionViaPhysicianPod.ActiveContext = base.ActiveContext;
			}
			if(_stateCollectionViaPhysicianLicense!=null)
			{
				_stateCollectionViaPhysicianLicense.ActiveContext = base.ActiveContext;
			}
			if(_stateCollectionViaPhysicianLabTest!=null)
			{
				_stateCollectionViaPhysicianLabTest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaPhysicianPermittedTest!=null)
			{
				_testCollectionViaPhysicianPermittedTest.ActiveContext = base.ActiveContext;
			}
			if(_file_!=null)
			{
				_file_.ActiveContext = base.ActiveContext;
			}
			if(_file!=null)
			{
				_file.ActiveContext = base.ActiveContext;
			}
			if(_mvuserClassification!=null)
			{
				_mvuserClassification.ActiveContext = base.ActiveContext;
			}
			if(_physicianSpecialization!=null)
			{
				_physicianSpecialization.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_physicianCustomerPayRate!=null)
			{
				_physicianCustomerPayRate.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerSkipReview = null;
			_eventCustomerEvaluationLock = null;
			_physicianCustomerAssignment_ = null;
			_physicianCustomerAssignment = null;
			_physicianEarnings = null;
			_physicianEvaluation = null;
			_physicianEventAssignment_ = null;
			_physicianEventAssignment = null;
			_physicianInvoice = null;
			_physicianLabTest = null;
			_physicianLicense = null;
			_physicianPermittedTest = null;
			_physicianPod = null;
			_screeningAuthorization = null;
			_eventCustomersCollectionViaPhysicianEvaluation = null;
			_eventCustomersCollectionViaPhysicianCustomerAssignment_ = null;
			_eventCustomersCollectionViaPhysicianCustomerAssignment = null;
			_eventsCollectionViaPhysicianEventAssignment_ = null;
			_eventsCollectionViaPhysicianEventAssignment = null;
			_physicianEvaluationCollectionViaPhysicianEarnings = null;
			_podDetailsCollectionViaPhysicianPod = null;
			_stateCollectionViaPhysicianLicense = null;
			_stateCollectionViaPhysicianLabTest = null;
			_testCollectionViaPhysicianPermittedTest = null;
			_file_ = null;
			_file = null;
			_mvuserClassification = null;
			_physicianSpecialization = null;
			_organizationRoleUser = null;
			_physicianCustomerPayRate = null;
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

			_fieldsCustomProperties.Add("PhysicianId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResumeFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DigitalSignatureFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SpecializationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClassificationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowEarningAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsAuthorizationAllowed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkipAudit", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CutOffDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefaultPhysician", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DisplayName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdateResultEntry", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Npi", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _file_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", PhysicianProfileEntity.Relations.FileEntityUsingDigitalSignatureFileId, true, signalRelatedEntity, "PhysicianProfile_", resetFKFields, new int[] { (int)PhysicianProfileFieldIndex.DigitalSignatureFileId } );		
			_file_ = null;
		}

		/// <summary> setups the sync logic for member _file_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile_(IEntity2 relatedEntity)
		{
			if(_file_!=relatedEntity)
			{
				DesetupSyncFile_(true, true);
				_file_ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", PhysicianProfileEntity.Relations.FileEntityUsingDigitalSignatureFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", PhysicianProfileEntity.Relations.FileEntityUsingResumeFileId, true, signalRelatedEntity, "PhysicianProfile", resetFKFields, new int[] { (int)PhysicianProfileFieldIndex.ResumeFileId } );		
			_file = null;
		}

		/// <summary> setups the sync logic for member _file</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile(IEntity2 relatedEntity)
		{
			if(_file!=relatedEntity)
			{
				DesetupSyncFile(true, true);
				_file = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", PhysicianProfileEntity.Relations.FileEntityUsingResumeFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _mvuserClassification</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMvuserClassification(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _mvuserClassification, new PropertyChangedEventHandler( OnMvuserClassificationPropertyChanged ), "MvuserClassification", PhysicianProfileEntity.Relations.MvuserClassificationEntityUsingClassificationId, true, signalRelatedEntity, "PhysicianProfile", resetFKFields, new int[] { (int)PhysicianProfileFieldIndex.ClassificationId } );		
			_mvuserClassification = null;
		}

		/// <summary> setups the sync logic for member _mvuserClassification</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMvuserClassification(IEntity2 relatedEntity)
		{
			if(_mvuserClassification!=relatedEntity)
			{
				DesetupSyncMvuserClassification(true, true);
				_mvuserClassification = (MvuserClassificationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _mvuserClassification, new PropertyChangedEventHandler( OnMvuserClassificationPropertyChanged ), "MvuserClassification", PhysicianProfileEntity.Relations.MvuserClassificationEntityUsingClassificationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMvuserClassificationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _physicianSpecialization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPhysicianSpecialization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _physicianSpecialization, new PropertyChangedEventHandler( OnPhysicianSpecializationPropertyChanged ), "PhysicianSpecialization", PhysicianProfileEntity.Relations.PhysicianSpecializationEntityUsingSpecializationId, true, signalRelatedEntity, "PhysicianProfile", resetFKFields, new int[] { (int)PhysicianProfileFieldIndex.SpecializationId } );		
			_physicianSpecialization = null;
		}

		/// <summary> setups the sync logic for member _physicianSpecialization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPhysicianSpecialization(IEntity2 relatedEntity)
		{
			if(_physicianSpecialization!=relatedEntity)
			{
				DesetupSyncPhysicianSpecialization(true, true);
				_physicianSpecialization = (PhysicianSpecializationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _physicianSpecialization, new PropertyChangedEventHandler( OnPhysicianSpecializationPropertyChanged ), "PhysicianSpecialization", PhysicianProfileEntity.Relations.PhysicianSpecializationEntityUsingSpecializationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPhysicianSpecializationPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", PhysicianProfileEntity.Relations.OrganizationRoleUserEntityUsingPhysicianId, true, signalRelatedEntity, "PhysicianProfile", false, new int[] { (int)PhysicianProfileFieldIndex.PhysicianId } );
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", PhysicianProfileEntity.Relations.OrganizationRoleUserEntityUsingPhysicianId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _physicianCustomerPayRate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPhysicianCustomerPayRate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _physicianCustomerPayRate, new PropertyChangedEventHandler( OnPhysicianCustomerPayRatePropertyChanged ), "PhysicianCustomerPayRate", PhysicianProfileEntity.Relations.PhysicianCustomerPayRateEntityUsingPhysicianId, false, signalRelatedEntity, "PhysicianProfile", false, new int[] { (int)PhysicianProfileFieldIndex.PhysicianId } );
			_physicianCustomerPayRate = null;
		}
		
		/// <summary> setups the sync logic for member _physicianCustomerPayRate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPhysicianCustomerPayRate(IEntity2 relatedEntity)
		{
			if(_physicianCustomerPayRate!=relatedEntity)
			{
				DesetupSyncPhysicianCustomerPayRate(true, true);
				_physicianCustomerPayRate = (PhysicianCustomerPayRateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _physicianCustomerPayRate, new PropertyChangedEventHandler( OnPhysicianCustomerPayRatePropertyChanged ), "PhysicianCustomerPayRate", PhysicianProfileEntity.Relations.PhysicianCustomerPayRateEntityUsingPhysicianId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPhysicianCustomerPayRatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PhysicianProfileEntity</param>
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
		public  static PhysicianProfileRelations Relations
		{
			get	{ return new PhysicianProfileRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerSkipReview' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerSkipReview
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerSkipReviewEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerSkipReviewEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerSkipReview")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.CustomerSkipReviewEntity, 0, null, null, null, null, "CustomerSkipReview", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerEvaluationLock' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerEvaluationLock
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerEvaluationLockEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEvaluationLockEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerEvaluationLock")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.EventCustomerEvaluationLockEntity, 0, null, null, null, null, "EventCustomerEvaluationLock", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianCustomerAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianCustomerAssignment_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianCustomerAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianCustomerAssignment_")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianCustomerAssignmentEntity, 0, null, null, null, null, "PhysicianCustomerAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianCustomerAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianCustomerAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianCustomerAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianCustomerAssignment")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianCustomerAssignmentEntity, 0, null, null, null, null, "PhysicianCustomerAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianEarnings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianEarnings
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianEarningsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEarningsEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianEarnings")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianEarningsEntity, 0, null, null, null, null, "PhysicianEarnings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianEvaluation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianEvaluation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianEvaluation")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianEvaluationEntity, 0, null, null, null, null, "PhysicianEvaluation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianEventAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianEventAssignment_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianEventAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEventAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianEventAssignment_")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianEventAssignmentEntity, 0, null, null, null, null, "PhysicianEventAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianEventAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianEventAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianEventAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEventAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianEventAssignment")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianEventAssignmentEntity, 0, null, null, null, null, "PhysicianEventAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianInvoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianInvoice
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianInvoice")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianInvoiceEntity, 0, null, null, null, null, "PhysicianInvoice", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianLabTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianLabTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianLabTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLabTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianLabTest")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianLabTestEntity, 0, null, null, null, null, "PhysicianLabTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianLicense' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianLicense
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianLicenseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLicenseEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianLicense")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianLicenseEntity, 0, null, null, null, null, "PhysicianLicense", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianPermittedTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianPermittedTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianPermittedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPermittedTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianPermittedTest")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianPermittedTestEntity, 0, null, null, null, null, "PhysicianPermittedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("PhysicianPod")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianPodEntity, 0, null, null, null, null, "PhysicianPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScreeningAuthorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScreeningAuthorization
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ScreeningAuthorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScreeningAuthorizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("ScreeningAuthorization")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.ScreeningAuthorizationEntity, 0, null, null, null, null, "ScreeningAuthorization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaPhysicianEvaluation
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianEvaluationEntityUsingPhysicianId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianEvaluation_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaPhysicianEvaluation"), null, "EventCustomersCollectionViaPhysicianEvaluation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaPhysicianCustomerAssignment_
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianCustomerAssignmentEntityUsingPhysicianId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianCustomerAssignment_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaPhysicianCustomerAssignment_"), null, "EventCustomersCollectionViaPhysicianCustomerAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaPhysicianCustomerAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianCustomerAssignmentEntityUsingOverReadPhysicianId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianCustomerAssignment_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaPhysicianCustomerAssignment"), null, "EventCustomersCollectionViaPhysicianCustomerAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaPhysicianEventAssignment_
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianEventAssignmentEntityUsingPhysicianId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianEventAssignment_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaPhysicianEventAssignment_"), null, "EventsCollectionViaPhysicianEventAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaPhysicianEventAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianEventAssignmentEntityUsingOverReadPhysicianId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianEventAssignment_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaPhysicianEventAssignment"), null, "EventsCollectionViaPhysicianEventAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianEvaluation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianEvaluationCollectionViaPhysicianEarnings
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianEarningsEntityUsingPhysicianId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianEarnings_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianEvaluationEntity, 0, null, null, GetRelationsForField("PhysicianEvaluationCollectionViaPhysicianEarnings"), null, "PhysicianEvaluationCollectionViaPhysicianEarnings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaPhysicianPod
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianPodEntityUsingPhysicianId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianPod_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaPhysicianPod"), null, "PodDetailsCollectionViaPhysicianPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'State' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStateCollectionViaPhysicianLicense
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianLicenseEntityUsingPhysicianId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianLicense_");
				return new PrefetchPathElement2(new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.StateEntity, 0, null, null, GetRelationsForField("StateCollectionViaPhysicianLicense"), null, "StateCollectionViaPhysicianLicense", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'State' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStateCollectionViaPhysicianLabTest
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianLabTestEntityUsingPhysicianId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianLabTest_");
				return new PrefetchPathElement2(new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.StateEntity, 0, null, null, GetRelationsForField("StateCollectionViaPhysicianLabTest"), null, "StateCollectionViaPhysicianLabTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaPhysicianPermittedTest
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianProfileEntity.Relations.PhysicianPermittedTestEntityUsingOrganizationRoleUserId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianPermittedTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaPhysicianPermittedTest"), null, "TestCollectionViaPhysicianPermittedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File_")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MvuserClassification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvuserClassification
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MvuserClassificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("MvuserClassification")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.MvuserClassificationEntity, 0, null, null, null, null, "MvuserClassification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianSpecialization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianSpecialization
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianSpecializationEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianSpecialization")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianSpecializationEntity, 0, null, null, null, null, "PhysicianSpecialization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianCustomerPayRate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianCustomerPayRate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerPayRateEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianCustomerPayRate")[0], (int)Falcon.Data.EntityType.PhysicianProfileEntity, (int)Falcon.Data.EntityType.PhysicianCustomerPayRateEntity, 0, null, null, null, null, "PhysicianCustomerPayRate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PhysicianProfileEntity.CustomProperties;}
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
			get { return PhysicianProfileEntity.FieldsCustomProperties;}
		}

		/// <summary> The PhysicianId property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."PhysicianID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 PhysicianId
		{
			get { return (System.Int64)GetValue((int)PhysicianProfileFieldIndex.PhysicianId, true); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.PhysicianId, value); }
		}

		/// <summary> The ResumeFileId property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."ResumeFileID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ResumeFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PhysicianProfileFieldIndex.ResumeFileId, false); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.ResumeFileId, value); }
		}

		/// <summary> The DigitalSignatureFileId property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."DigitalSignatureFileID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DigitalSignatureFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PhysicianProfileFieldIndex.DigitalSignatureFileId, false); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.DigitalSignatureFileId, value); }
		}

		/// <summary> The SpecializationId property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."SpecializationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SpecializationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PhysicianProfileFieldIndex.SpecializationId, false); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.SpecializationId, value); }
		}

		/// <summary> The ClassificationId property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."ClassificationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ClassificationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PhysicianProfileFieldIndex.ClassificationId, false); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.ClassificationId, value); }
		}

		/// <summary> The ShowEarningAmount property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."ShowEarningAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowEarningAmount
		{
			get { return (System.Boolean)GetValue((int)PhysicianProfileFieldIndex.ShowEarningAmount, true); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.ShowEarningAmount, value); }
		}

		/// <summary> The IsAuthorizationAllowed property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."IsAuthorizationAllowed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsAuthorizationAllowed
		{
			get { return (System.Boolean)GetValue((int)PhysicianProfileFieldIndex.IsAuthorizationAllowed, true); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.IsAuthorizationAllowed, value); }
		}

		/// <summary> The SkipAudit property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."SkipAudit"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SkipAudit
		{
			get { return (System.Boolean)GetValue((int)PhysicianProfileFieldIndex.SkipAudit, true); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.SkipAudit, value); }
		}

		/// <summary> The CutOffDate property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."CutOffDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CutOffDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PhysicianProfileFieldIndex.CutOffDate, false); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.CutOffDate, value); }
		}

		/// <summary> The IsDefaultPhysician property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."IsDefaultPhysician"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefaultPhysician
		{
			get { return (System.Boolean)GetValue((int)PhysicianProfileFieldIndex.IsDefaultPhysician, true); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.IsDefaultPhysician, value); }
		}

		/// <summary> The DisplayName property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."DisplayName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DisplayName
		{
			get { return (System.String)GetValue((int)PhysicianProfileFieldIndex.DisplayName, true); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.DisplayName, value); }
		}

		/// <summary> The UpdateResultEntry property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."UpdateResultEntry"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean UpdateResultEntry
		{
			get { return (System.Boolean)GetValue((int)PhysicianProfileFieldIndex.UpdateResultEntry, true); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.UpdateResultEntry, value); }
		}

		/// <summary> The Npi property of the Entity PhysicianProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianProfile"."Npi"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Npi
		{
			get { return (System.String)GetValue((int)PhysicianProfileFieldIndex.Npi, true); }
			set	{ SetValue((int)PhysicianProfileFieldIndex.Npi, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerSkipReviewEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerSkipReviewEntity))]
		public virtual EntityCollection<CustomerSkipReviewEntity> CustomerSkipReview
		{
			get
			{
				if(_customerSkipReview==null)
				{
					_customerSkipReview = new EntityCollection<CustomerSkipReviewEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerSkipReviewEntityFactory)));
					_customerSkipReview.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _customerSkipReview;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerEvaluationLockEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerEvaluationLockEntity))]
		public virtual EntityCollection<EventCustomerEvaluationLockEntity> EventCustomerEvaluationLock
		{
			get
			{
				if(_eventCustomerEvaluationLock==null)
				{
					_eventCustomerEvaluationLock = new EntityCollection<EventCustomerEvaluationLockEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEvaluationLockEntityFactory)));
					_eventCustomerEvaluationLock.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _eventCustomerEvaluationLock;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianCustomerAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianCustomerAssignmentEntity))]
		public virtual EntityCollection<PhysicianCustomerAssignmentEntity> PhysicianCustomerAssignment_
		{
			get
			{
				if(_physicianCustomerAssignment_==null)
				{
					_physicianCustomerAssignment_ = new EntityCollection<PhysicianCustomerAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerAssignmentEntityFactory)));
					_physicianCustomerAssignment_.SetContainingEntityInfo(this, "PhysicianProfile_");
				}
				return _physicianCustomerAssignment_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianCustomerAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianCustomerAssignmentEntity))]
		public virtual EntityCollection<PhysicianCustomerAssignmentEntity> PhysicianCustomerAssignment
		{
			get
			{
				if(_physicianCustomerAssignment==null)
				{
					_physicianCustomerAssignment = new EntityCollection<PhysicianCustomerAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerAssignmentEntityFactory)));
					_physicianCustomerAssignment.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _physicianCustomerAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianEarningsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianEarningsEntity))]
		public virtual EntityCollection<PhysicianEarningsEntity> PhysicianEarnings
		{
			get
			{
				if(_physicianEarnings==null)
				{
					_physicianEarnings = new EntityCollection<PhysicianEarningsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEarningsEntityFactory)));
					_physicianEarnings.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _physicianEarnings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianEvaluationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianEvaluationEntity))]
		public virtual EntityCollection<PhysicianEvaluationEntity> PhysicianEvaluation
		{
			get
			{
				if(_physicianEvaluation==null)
				{
					_physicianEvaluation = new EntityCollection<PhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory)));
					_physicianEvaluation.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _physicianEvaluation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianEventAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianEventAssignmentEntity))]
		public virtual EntityCollection<PhysicianEventAssignmentEntity> PhysicianEventAssignment_
		{
			get
			{
				if(_physicianEventAssignment_==null)
				{
					_physicianEventAssignment_ = new EntityCollection<PhysicianEventAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEventAssignmentEntityFactory)));
					_physicianEventAssignment_.SetContainingEntityInfo(this, "PhysicianProfile_");
				}
				return _physicianEventAssignment_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianEventAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianEventAssignmentEntity))]
		public virtual EntityCollection<PhysicianEventAssignmentEntity> PhysicianEventAssignment
		{
			get
			{
				if(_physicianEventAssignment==null)
				{
					_physicianEventAssignment = new EntityCollection<PhysicianEventAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEventAssignmentEntityFactory)));
					_physicianEventAssignment.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _physicianEventAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianInvoiceEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianInvoiceEntity))]
		public virtual EntityCollection<PhysicianInvoiceEntity> PhysicianInvoice
		{
			get
			{
				if(_physicianInvoice==null)
				{
					_physicianInvoice = new EntityCollection<PhysicianInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory)));
					_physicianInvoice.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _physicianInvoice;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianLabTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianLabTestEntity))]
		public virtual EntityCollection<PhysicianLabTestEntity> PhysicianLabTest
		{
			get
			{
				if(_physicianLabTest==null)
				{
					_physicianLabTest = new EntityCollection<PhysicianLabTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLabTestEntityFactory)));
					_physicianLabTest.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _physicianLabTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianLicenseEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianLicenseEntity))]
		public virtual EntityCollection<PhysicianLicenseEntity> PhysicianLicense
		{
			get
			{
				if(_physicianLicense==null)
				{
					_physicianLicense = new EntityCollection<PhysicianLicenseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLicenseEntityFactory)));
					_physicianLicense.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _physicianLicense;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianPermittedTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianPermittedTestEntity))]
		public virtual EntityCollection<PhysicianPermittedTestEntity> PhysicianPermittedTest
		{
			get
			{
				if(_physicianPermittedTest==null)
				{
					_physicianPermittedTest = new EntityCollection<PhysicianPermittedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPermittedTestEntityFactory)));
					_physicianPermittedTest.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _physicianPermittedTest;
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
					_physicianPod.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _physicianPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ScreeningAuthorizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ScreeningAuthorizationEntity))]
		public virtual EntityCollection<ScreeningAuthorizationEntity> ScreeningAuthorization
		{
			get
			{
				if(_screeningAuthorization==null)
				{
					_screeningAuthorization = new EntityCollection<ScreeningAuthorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScreeningAuthorizationEntityFactory)));
					_screeningAuthorization.SetContainingEntityInfo(this, "PhysicianProfile");
				}
				return _screeningAuthorization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaPhysicianEvaluation
		{
			get
			{
				if(_eventCustomersCollectionViaPhysicianEvaluation==null)
				{
					_eventCustomersCollectionViaPhysicianEvaluation = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaPhysicianEvaluation.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaPhysicianEvaluation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaPhysicianCustomerAssignment_
		{
			get
			{
				if(_eventCustomersCollectionViaPhysicianCustomerAssignment_==null)
				{
					_eventCustomersCollectionViaPhysicianCustomerAssignment_ = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaPhysicianCustomerAssignment_.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaPhysicianCustomerAssignment_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaPhysicianCustomerAssignment
		{
			get
			{
				if(_eventCustomersCollectionViaPhysicianCustomerAssignment==null)
				{
					_eventCustomersCollectionViaPhysicianCustomerAssignment = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaPhysicianCustomerAssignment.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaPhysicianCustomerAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaPhysicianEventAssignment_
		{
			get
			{
				if(_eventsCollectionViaPhysicianEventAssignment_==null)
				{
					_eventsCollectionViaPhysicianEventAssignment_ = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaPhysicianEventAssignment_.IsReadOnly=true;
				}
				return _eventsCollectionViaPhysicianEventAssignment_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaPhysicianEventAssignment
		{
			get
			{
				if(_eventsCollectionViaPhysicianEventAssignment==null)
				{
					_eventsCollectionViaPhysicianEventAssignment = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaPhysicianEventAssignment.IsReadOnly=true;
				}
				return _eventsCollectionViaPhysicianEventAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianEvaluationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianEvaluationEntity))]
		public virtual EntityCollection<PhysicianEvaluationEntity> PhysicianEvaluationCollectionViaPhysicianEarnings
		{
			get
			{
				if(_physicianEvaluationCollectionViaPhysicianEarnings==null)
				{
					_physicianEvaluationCollectionViaPhysicianEarnings = new EntityCollection<PhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory)));
					_physicianEvaluationCollectionViaPhysicianEarnings.IsReadOnly=true;
				}
				return _physicianEvaluationCollectionViaPhysicianEarnings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaPhysicianPod
		{
			get
			{
				if(_podDetailsCollectionViaPhysicianPod==null)
				{
					_podDetailsCollectionViaPhysicianPod = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaPhysicianPod.IsReadOnly=true;
				}
				return _podDetailsCollectionViaPhysicianPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StateEntity))]
		public virtual EntityCollection<StateEntity> StateCollectionViaPhysicianLicense
		{
			get
			{
				if(_stateCollectionViaPhysicianLicense==null)
				{
					_stateCollectionViaPhysicianLicense = new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory)));
					_stateCollectionViaPhysicianLicense.IsReadOnly=true;
				}
				return _stateCollectionViaPhysicianLicense;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StateEntity))]
		public virtual EntityCollection<StateEntity> StateCollectionViaPhysicianLabTest
		{
			get
			{
				if(_stateCollectionViaPhysicianLabTest==null)
				{
					_stateCollectionViaPhysicianLabTest = new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory)));
					_stateCollectionViaPhysicianLabTest.IsReadOnly=true;
				}
				return _stateCollectionViaPhysicianLabTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaPhysicianPermittedTest
		{
			get
			{
				if(_testCollectionViaPhysicianPermittedTest==null)
				{
					_testCollectionViaPhysicianPermittedTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaPhysicianPermittedTest.IsReadOnly=true;
				}
				return _testCollectionViaPhysicianPermittedTest;
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File_
		{
			get
			{
				return _file_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile_(value);
				}
				else
				{
					if(value==null)
					{
						if(_file_ != null)
						{
							_file_.UnsetRelatedEntity(this, "PhysicianProfile_");
						}
					}
					else
					{
						if(_file_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianProfile_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File
		{
			get
			{
				return _file;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile(value);
				}
				else
				{
					if(value==null)
					{
						if(_file != null)
						{
							_file.UnsetRelatedEntity(this, "PhysicianProfile");
						}
					}
					else
					{
						if(_file!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianProfile");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MvuserClassificationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MvuserClassificationEntity MvuserClassification
		{
			get
			{
				return _mvuserClassification;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMvuserClassification(value);
				}
				else
				{
					if(value==null)
					{
						if(_mvuserClassification != null)
						{
							_mvuserClassification.UnsetRelatedEntity(this, "PhysicianProfile");
						}
					}
					else
					{
						if(_mvuserClassification!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianProfile");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PhysicianSpecializationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PhysicianSpecializationEntity PhysicianSpecialization
		{
			get
			{
				return _physicianSpecialization;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPhysicianSpecialization(value);
				}
				else
				{
					if(value==null)
					{
						if(_physicianSpecialization != null)
						{
							_physicianSpecialization.UnsetRelatedEntity(this, "PhysicianProfile");
						}
					}
					else
					{
						if(_physicianSpecialization!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianProfile");
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
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "PhysicianProfile");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_organizationRoleUser !=null);
						DesetupSyncOrganizationRoleUser(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("OrganizationRoleUser");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "PhysicianProfile");
							SetupSyncOrganizationRoleUser(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PhysicianCustomerPayRateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PhysicianCustomerPayRateEntity PhysicianCustomerPayRate
		{
			get
			{
				return _physicianCustomerPayRate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPhysicianCustomerPayRate(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "PhysicianProfile");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_physicianCustomerPayRate !=null);
						DesetupSyncPhysicianCustomerPayRate(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("PhysicianCustomerPayRate");
						}
					}
					else
					{
						if(_physicianCustomerPayRate!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "PhysicianProfile");
							SetupSyncPhysicianCustomerPayRate(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.PhysicianProfileEntity; }
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
