///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using Falcon.Data;
using Falcon.Data.FactoryClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: PhysicianProfile. </summary>
	public partial class PhysicianProfileRelations
	{
		/// <summary>CTor</summary>
		public PhysicianProfileRelations()
		{
		}

		/// <summary>Gets all relations of the PhysicianProfileEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerSkipReviewEntityUsingDefaultPhysicianId);
			toReturn.Add(this.EventCustomerEvaluationLockEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianCustomerAssignmentEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianCustomerAssignmentEntityUsingOverReadPhysicianId);
			toReturn.Add(this.PhysicianEarningsEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianEvaluationEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianEventAssignmentEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianEventAssignmentEntityUsingOverReadPhysicianId);
			toReturn.Add(this.PhysicianInvoiceEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianLabTestEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianLicenseEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianPermittedTestEntityUsingOrganizationRoleUserId);
			toReturn.Add(this.PhysicianPodEntityUsingPhysicianId);
			toReturn.Add(this.ScreeningAuthorizationEntityUsingPhysicianOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianCustomerPayRateEntityUsingPhysicianId);
			toReturn.Add(this.FileEntityUsingDigitalSignatureFileId);
			toReturn.Add(this.FileEntityUsingResumeFileId);
			toReturn.Add(this.MvuserClassificationEntityUsingClassificationId);
			toReturn.Add(this.PhysicianSpecializationEntityUsingSpecializationId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and CustomerSkipReviewEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - CustomerSkipReview.DefaultPhysicianId
		/// </summary>
		public virtual IEntityRelation CustomerSkipReviewEntityUsingDefaultPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerSkipReview" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, CustomerSkipReviewFields.DefaultPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerSkipReviewEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and EventCustomerEvaluationLockEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - EventCustomerEvaluationLock.PhysicianId
		/// </summary>
		public virtual IEntityRelation EventCustomerEvaluationLockEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerEvaluationLock" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, EventCustomerEvaluationLockFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerEvaluationLockEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianCustomerAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianCustomerAssignment.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianCustomerAssignmentEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianCustomerAssignment_" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianCustomerAssignmentFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianCustomerAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianCustomerAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianCustomerAssignment.OverReadPhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianCustomerAssignmentEntityUsingOverReadPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianCustomerAssignment" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianCustomerAssignmentFields.OverReadPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianCustomerAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianEarningsEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianEarnings.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianEarningsEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianEarnings" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianEarningsFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEarningsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianEvaluationEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianEvaluation.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianEvaluationEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianEvaluation" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianEvaluationFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEvaluationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianEventAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianEventAssignment.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianEventAssignmentEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianEventAssignment_" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianEventAssignmentFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEventAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianEventAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianEventAssignment.OverReadPhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianEventAssignmentEntityUsingOverReadPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianEventAssignment" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianEventAssignmentFields.OverReadPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEventAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianInvoiceEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianInvoice.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianInvoiceEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianInvoice" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianInvoiceFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianLabTestEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianLabTest.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianLabTestEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianLabTest" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianLabTestFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianLabTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianLicenseEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianLicense.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianLicenseEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianLicense" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianLicenseFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianLicenseEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianPermittedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianPermittedTest.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation PhysicianPermittedTestEntityUsingOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianPermittedTest" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianPermittedTestFields.OrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPermittedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianPodEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianPod.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianPodEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianPod" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianPodFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPodEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and ScreeningAuthorizationEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - ScreeningAuthorization.PhysicianOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation ScreeningAuthorizationEntityUsingPhysicianOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ScreeningAuthorization" , true);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, ScreeningAuthorizationFields.PhysicianOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScreeningAuthorizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and OrganizationRoleUserEntity over the 1:1 relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "OrganizationRoleUser", false);



				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PhysicianProfileFields.PhysicianId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianCustomerPayRateEntity over the 1:1 relation they have, using the relation between the fields:
		/// PhysicianProfile.PhysicianId - PhysicianCustomerPayRate.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianCustomerPayRateEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "PhysicianCustomerPayRate", true);

				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianCustomerPayRateFields.PhysicianId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianCustomerPayRateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianProfile.DigitalSignatureFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingDigitalSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, PhysicianProfileFields.DigitalSignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianProfile.ResumeFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingResumeFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, PhysicianProfileFields.ResumeFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and MvuserClassificationEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianProfile.ClassificationId - MvuserClassification.MvuserClassificationId
		/// </summary>
		public virtual IEntityRelation MvuserClassificationEntityUsingClassificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MvuserClassification", false);
				relation.AddEntityFieldPair(MvuserClassificationFields.MvuserClassificationId, PhysicianProfileFields.ClassificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MvuserClassificationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianProfileEntity and PhysicianSpecializationEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianProfile.SpecializationId - PhysicianSpecialization.PhysicianSpecializationId
		/// </summary>
		public virtual IEntityRelation PhysicianSpecializationEntityUsingSpecializationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianSpecialization", false);
				relation.AddEntityFieldPair(PhysicianSpecializationFields.PhysicianSpecializationId, PhysicianProfileFields.SpecializationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianSpecializationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", true);
				return relation;
			}
		}

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
