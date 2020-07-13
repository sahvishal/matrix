///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:38
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
	/// <summary>Implements the static Relations variant for the entity: Test. </summary>
	public partial class TestRelations
	{
		/// <summary>CTor</summary>
		public TestRelations()
		{
		}

		/// <summary>Gets all relations of the TestEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountCustomerResultTestDependencyEntityUsingTestId);
			toReturn.Add(this.AccountHealthPlanResultTestDependencyEntityUsingTestId);
			toReturn.Add(this.AccountNotReviewableTestEntityUsingTestId);
			toReturn.Add(this.AccountPcpResultTestDependencyEntityUsingTestId);
			toReturn.Add(this.AccountTestEntityUsingTestId);
			toReturn.Add(this.BillingAccountTestEntityUsingTestId);
			toReturn.Add(this.ClinicalTestQualificationCriteriaEntityUsingTestId);
			toReturn.Add(this.CustomerEventScreeningTestsEntityUsingTestId);
			toReturn.Add(this.CustomerEventTestFindingEntityUsingTestId);
			toReturn.Add(this.CustomerHealthQuestionGroupEntityUsingTestId);
			toReturn.Add(this.DependentDisqualifiedTestEntityUsingTestId);
			toReturn.Add(this.DisqualifiedTestEntityUsingTestId);
			toReturn.Add(this.EventCustomerPreApprovedPackageTestEntityUsingTestId);
			toReturn.Add(this.EventCustomerPreApprovedTestEntityUsingTestId);
			toReturn.Add(this.EventCustomerRequiredTestEntityUsingTestId);
			toReturn.Add(this.EventCustomerRetestEntityUsingTestId);
			toReturn.Add(this.EventCustomerTestNotPerformedNotificationEntityUsingTestId);
			toReturn.Add(this.EventPhysicianTestEntityUsingTestId);
			toReturn.Add(this.EventPodRoomTestEntityUsingTestId);
			toReturn.Add(this.EventTestEntityUsingTestId);
			toReturn.Add(this.HealthPlanRevenueItemEntityUsingTestId);
			toReturn.Add(this.InventoryItemTestEntityUsingTestId);
			toReturn.Add(this.KynLabValuesEntityUsingTestId);
			toReturn.Add(this.PackageTestEntityUsingTestId);
			toReturn.Add(this.PhysicianPermittedTestEntityUsingTestId);
			toReturn.Add(this.PodRoomTestEntityUsingTestId);
			toReturn.Add(this.PodTestEntityUsingTestId);
			toReturn.Add(this.PreApprovedTestEntityUsingTestId);
			toReturn.Add(this.PreQualificationQuestionEntityUsingTestId);
			toReturn.Add(this.PreQualificationTemplateDependentTestEntityUsingTestId);
			toReturn.Add(this.PreQualificationTestTemplateEntityUsingTestId);
			toReturn.Add(this.ProspectActivityEntityUsingActivityId);
			toReturn.Add(this.RequiredTestEntityUsingTestId);
			toReturn.Add(this.ResultArchiveUploadLogEntityUsingTestId);
			toReturn.Add(this.StaffEventRoleTestEntityUsingTestId);
			toReturn.Add(this.StandardFindingTestReadingEntityUsingTestId);
			toReturn.Add(this.TestDependencyRuleEntityUsingDependantTestId);
			toReturn.Add(this.TestDependencyRuleEntityUsingTestId);
			toReturn.Add(this.TestHcpcsCodeEntityUsingTestId);
			toReturn.Add(this.TestIncidentalFindingEntityUsingTestId);
			toReturn.Add(this.TestReadingEntityUsingTestId);
			toReturn.Add(this.TestSourceCodeDiscountEntityUsingTestId);
			toReturn.Add(this.TestUnableScreenReasonEntityUsingTestId);

			toReturn.Add(this.HafTemplateEntityUsingHafTemplateId);
			toReturn.Add(this.LookupEntityUsingResultEntryTypeId);
			toReturn.Add(this.LookupEntityUsingGroupId);
			toReturn.Add(this.LookupEntityUsingGender);
			toReturn.Add(this.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TestEntity and AccountCustomerResultTestDependencyEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - AccountCustomerResultTestDependency.TestId
		/// </summary>
		public virtual IEntityRelation AccountCustomerResultTestDependencyEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCustomerResultTestDependency" , true);
				relation.AddEntityFieldPair(TestFields.TestId, AccountCustomerResultTestDependencyFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCustomerResultTestDependencyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and AccountHealthPlanResultTestDependencyEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - AccountHealthPlanResultTestDependency.TestId
		/// </summary>
		public virtual IEntityRelation AccountHealthPlanResultTestDependencyEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountHealthPlanResultTestDependency" , true);
				relation.AddEntityFieldPair(TestFields.TestId, AccountHealthPlanResultTestDependencyFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountHealthPlanResultTestDependencyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and AccountNotReviewableTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - AccountNotReviewableTest.TestId
		/// </summary>
		public virtual IEntityRelation AccountNotReviewableTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountNotReviewableTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, AccountNotReviewableTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountNotReviewableTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and AccountPcpResultTestDependencyEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - AccountPcpResultTestDependency.TestId
		/// </summary>
		public virtual IEntityRelation AccountPcpResultTestDependencyEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountPcpResultTestDependency" , true);
				relation.AddEntityFieldPair(TestFields.TestId, AccountPcpResultTestDependencyFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountPcpResultTestDependencyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and AccountTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - AccountTest.TestId
		/// </summary>
		public virtual IEntityRelation AccountTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, AccountTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and BillingAccountTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - BillingAccountTest.TestId
		/// </summary>
		public virtual IEntityRelation BillingAccountTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BillingAccountTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, BillingAccountTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BillingAccountTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and ClinicalTestQualificationCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - ClinicalTestQualificationCriteria.TestId
		/// </summary>
		public virtual IEntityRelation ClinicalTestQualificationCriteriaEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClinicalTestQualificationCriteria" , true);
				relation.AddEntityFieldPair(TestFields.TestId, ClinicalTestQualificationCriteriaFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClinicalTestQualificationCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and CustomerEventScreeningTestsEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - CustomerEventScreeningTests.TestId
		/// </summary>
		public virtual IEntityRelation CustomerEventScreeningTestsEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventScreeningTests" , true);
				relation.AddEntityFieldPair(TestFields.TestId, CustomerEventScreeningTestsFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and CustomerEventTestFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - CustomerEventTestFinding.TestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestFindingEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestFinding" , true);
				relation.AddEntityFieldPair(TestFields.TestId, CustomerEventTestFindingFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestFindingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and CustomerHealthQuestionGroupEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - CustomerHealthQuestionGroup.TestId
		/// </summary>
		public virtual IEntityRelation CustomerHealthQuestionGroupEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthQuestionGroup" , true);
				relation.AddEntityFieldPair(TestFields.TestId, CustomerHealthQuestionGroupFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionGroupEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and DependentDisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - DependentDisqualifiedTest.TestId
		/// </summary>
		public virtual IEntityRelation DependentDisqualifiedTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DependentDisqualifiedTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, DependentDisqualifiedTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DependentDisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and DisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - DisqualifiedTest.TestId
		/// </summary>
		public virtual IEntityRelation DisqualifiedTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DisqualifiedTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, DisqualifiedTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and EventCustomerPreApprovedPackageTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - EventCustomerPreApprovedPackageTest.TestId
		/// </summary>
		public virtual IEntityRelation EventCustomerPreApprovedPackageTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerPreApprovedPackageTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, EventCustomerPreApprovedPackageTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerPreApprovedPackageTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and EventCustomerPreApprovedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - EventCustomerPreApprovedTest.TestId
		/// </summary>
		public virtual IEntityRelation EventCustomerPreApprovedTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerPreApprovedTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, EventCustomerPreApprovedTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerPreApprovedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and EventCustomerRequiredTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - EventCustomerRequiredTest.TestId
		/// </summary>
		public virtual IEntityRelation EventCustomerRequiredTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerRequiredTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, EventCustomerRequiredTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerRequiredTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and EventCustomerRetestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - EventCustomerRetest.TestId
		/// </summary>
		public virtual IEntityRelation EventCustomerRetestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerRetest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, EventCustomerRetestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerRetestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and EventCustomerTestNotPerformedNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - EventCustomerTestNotPerformedNotification.TestId
		/// </summary>
		public virtual IEntityRelation EventCustomerTestNotPerformedNotificationEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerTestNotPerformedNotification" , true);
				relation.AddEntityFieldPair(TestFields.TestId, EventCustomerTestNotPerformedNotificationFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerTestNotPerformedNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and EventPhysicianTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - EventPhysicianTest.TestId
		/// </summary>
		public virtual IEntityRelation EventPhysicianTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPhysicianTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, EventPhysicianTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPhysicianTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and EventPodRoomTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - EventPodRoomTest.TestId
		/// </summary>
		public virtual IEntityRelation EventPodRoomTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPodRoomTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, EventPodRoomTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodRoomTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and EventTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - EventTest.TestId
		/// </summary>
		public virtual IEntityRelation EventTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, EventTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and HealthPlanRevenueItemEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - HealthPlanRevenueItem.TestId
		/// </summary>
		public virtual IEntityRelation HealthPlanRevenueItemEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanRevenueItem" , true);
				relation.AddEntityFieldPair(TestFields.TestId, HealthPlanRevenueItemFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and InventoryItemTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - InventoryItemTest.TestId
		/// </summary>
		public virtual IEntityRelation InventoryItemTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InventoryItemTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, InventoryItemTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InventoryItemTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and KynLabValuesEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - KynLabValues.TestId
		/// </summary>
		public virtual IEntityRelation KynLabValuesEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "KynLabValues" , true);
				relation.AddEntityFieldPair(TestFields.TestId, KynLabValuesFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and PackageTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - PackageTest.TestId
		/// </summary>
		public virtual IEntityRelation PackageTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PackageTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, PackageTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and PhysicianPermittedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - PhysicianPermittedTest.TestId
		/// </summary>
		public virtual IEntityRelation PhysicianPermittedTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianPermittedTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, PhysicianPermittedTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPermittedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and PodRoomTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - PodRoomTest.TestId
		/// </summary>
		public virtual IEntityRelation PodRoomTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodRoomTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, PodRoomTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodRoomTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and PodTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - PodTest.TestId
		/// </summary>
		public virtual IEntityRelation PodTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, PodTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and PreApprovedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - PreApprovedTest.TestId
		/// </summary>
		public virtual IEntityRelation PreApprovedTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreApprovedTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, PreApprovedTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreApprovedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and PreQualificationQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - PreQualificationQuestion.TestId
		/// </summary>
		public virtual IEntityRelation PreQualificationQuestionEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationQuestion" , true);
				relation.AddEntityFieldPair(TestFields.TestId, PreQualificationQuestionFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and PreQualificationTemplateDependentTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - PreQualificationTemplateDependentTest.TestId
		/// </summary>
		public virtual IEntityRelation PreQualificationTemplateDependentTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationTemplateDependentTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, PreQualificationTemplateDependentTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTemplateDependentTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and PreQualificationTestTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - PreQualificationTestTemplate.TestId
		/// </summary>
		public virtual IEntityRelation PreQualificationTestTemplateEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationTestTemplate" , true);
				relation.AddEntityFieldPair(TestFields.TestId, PreQualificationTestTemplateFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and ProspectActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - ProspectActivity.ActivityId
		/// </summary>
		public virtual IEntityRelation ProspectActivityEntityUsingActivityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectActivity" , true);
				relation.AddEntityFieldPair(TestFields.TestId, ProspectActivityFields.ActivityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectActivityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and RequiredTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - RequiredTest.TestId
		/// </summary>
		public virtual IEntityRelation RequiredTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RequiredTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, RequiredTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RequiredTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and ResultArchiveUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - ResultArchiveUploadLog.TestId
		/// </summary>
		public virtual IEntityRelation ResultArchiveUploadLogEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ResultArchiveUploadLog" , true);
				relation.AddEntityFieldPair(TestFields.TestId, ResultArchiveUploadLogFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultArchiveUploadLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and StaffEventRoleTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - StaffEventRoleTest.TestId
		/// </summary>
		public virtual IEntityRelation StaffEventRoleTestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StaffEventRoleTest" , true);
				relation.AddEntityFieldPair(TestFields.TestId, StaffEventRoleTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventRoleTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and StandardFindingTestReadingEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - StandardFindingTestReading.TestId
		/// </summary>
		public virtual IEntityRelation StandardFindingTestReadingEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StandardFindingTestReading" , true);
				relation.AddEntityFieldPair(TestFields.TestId, StandardFindingTestReadingFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingTestReadingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and TestDependencyRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - TestDependencyRule.DependantTestId
		/// </summary>
		public virtual IEntityRelation TestDependencyRuleEntityUsingDependantTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestDependencyRule" , true);
				relation.AddEntityFieldPair(TestFields.TestId, TestDependencyRuleFields.DependantTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestDependencyRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and TestDependencyRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - TestDependencyRule.TestId
		/// </summary>
		public virtual IEntityRelation TestDependencyRuleEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestDependencyRule_" , true);
				relation.AddEntityFieldPair(TestFields.TestId, TestDependencyRuleFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestDependencyRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and TestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - TestHcpcsCode.TestId
		/// </summary>
		public virtual IEntityRelation TestHcpcsCodeEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestHcpcsCode" , true);
				relation.AddEntityFieldPair(TestFields.TestId, TestHcpcsCodeFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and TestIncidentalFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - TestIncidentalFinding.TestId
		/// </summary>
		public virtual IEntityRelation TestIncidentalFindingEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestIncidentalFinding" , true);
				relation.AddEntityFieldPair(TestFields.TestId, TestIncidentalFindingFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestIncidentalFindingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and TestReadingEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - TestReading.TestId
		/// </summary>
		public virtual IEntityRelation TestReadingEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestReading" , true);
				relation.AddEntityFieldPair(TestFields.TestId, TestReadingFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestReadingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and TestSourceCodeDiscountEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - TestSourceCodeDiscount.TestId
		/// </summary>
		public virtual IEntityRelation TestSourceCodeDiscountEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestSourceCodeDiscount" , true);
				relation.AddEntityFieldPair(TestFields.TestId, TestSourceCodeDiscountFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestSourceCodeDiscountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestEntity and TestUnableScreenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// Test.TestId - TestUnableScreenReason.TestId
		/// </summary>
		public virtual IEntityRelation TestUnableScreenReasonEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestUnableScreenReason" , true);
				relation.AddEntityFieldPair(TestFields.TestId, TestUnableScreenReasonFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestUnableScreenReasonEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TestEntity and HafTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Test.HafTemplateId - HafTemplate.HaftemplateId
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HafTemplate", false);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, TestFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Test.ResultEntryTypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingResultEntryTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup__", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, TestFields.ResultEntryTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Test.GroupId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, TestFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Test.Gender - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, TestFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestEntity and PreQualificationTestTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Test.PreQualificationQuestionTemplateId - PreQualificationTestTemplate.Id
		/// </summary>
		public virtual IEntityRelation PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PreQualificationTestTemplate_", false);
				relation.AddEntityFieldPair(PreQualificationTestTemplateFields.Id, TestFields.PreQualificationQuestionTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", true);
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
