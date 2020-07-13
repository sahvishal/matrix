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
	/// <summary>Implements the static Relations variant for the entity: CustomerEventScreeningTests. </summary>
	public partial class CustomerEventScreeningTestsRelations
	{
		/// <summary>CTor</summary>
		public CustomerEventScreeningTestsRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerEventScreeningTestsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerEventReadingEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.CustomerEventTestIncidentalFindingEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.CustomerEventTestPhysicianEvaluationEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.CustomerEventTestStandardFindingEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.CustomerEventUnableScreenReasonEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.TestMediaEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.TestNotPerformedEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.TestPerformedExternallyEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.CustomerEventCriticalTestDataEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.CustomerEventPriorityInQueueDataEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.EventCustomerResultEntityUsingEventCustomerResultId);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and CustomerEventReadingEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - CustomerEventReading.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventReadingEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventReading" , true);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventReadingFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventReadingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and CustomerEventTestIncidentalFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - CustomerEventTestIncidentalFinding.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestIncidentalFindingEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestIncidentalFinding" , true);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventTestIncidentalFindingFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and CustomerEventTestPhysicianEvaluationEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - CustomerEventTestPhysicianEvaluation.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestPhysicianEvaluationEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestPhysicianEvaluation" , true);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventTestPhysicianEvaluationFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestPhysicianEvaluationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and CustomerEventTestStandardFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - CustomerEventTestStandardFinding.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestStandardFindingEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestStandardFinding" , true);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventTestStandardFindingFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestStandardFindingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and CustomerEventTestStateEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - CustomerEventTestState.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestStateEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestState" , true);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventTestStateFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestStateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and CustomerEventUnableScreenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - CustomerEventUnableScreenReason.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventUnableScreenReasonEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventUnableScreenReason" , true);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventUnableScreenReasonFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventUnableScreenReasonEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and TestMediaEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - TestMedia.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation TestMediaEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestMedia" , true);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, TestMediaFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestMediaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and TestNotPerformedEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - TestNotPerformed.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation TestNotPerformedEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestNotPerformed" , true);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, TestNotPerformedFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestNotPerformedEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and TestPerformedExternallyEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - TestPerformedExternally.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation TestPerformedExternallyEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestPerformedExternally" , true);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, TestPerformedExternallyFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestPerformedExternallyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and CustomerEventCriticalTestDataEntity over the 1:1 relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - CustomerEventCriticalTestData.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventCriticalTestDataEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CustomerEventCriticalTestData", true);

				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventCriticalTestDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and CustomerEventPriorityInQueueDataEntity over the 1:1 relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.CustomerEventScreeningTestId - CustomerEventPriorityInQueueData.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventPriorityInQueueDataEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CustomerEventPriorityInQueueData", true);

				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventPriorityInQueueDataFields.CustomerEventScreeningTestId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventPriorityInQueueDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and EventCustomerResultEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.EventCustomerResultId - EventCustomerResult.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomerResult", false);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, CustomerEventScreeningTestsFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerEventScreeningTestsEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventScreeningTests.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, CustomerEventScreeningTestsFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", true);
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
