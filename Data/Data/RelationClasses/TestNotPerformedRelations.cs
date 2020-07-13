///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:40
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
	/// <summary>Implements the static Relations variant for the entity: TestNotPerformed. </summary>
	public partial class TestNotPerformedRelations
	{
		/// <summary>CTor</summary>
		public TestNotPerformedRelations()
		{
		}

		/// <summary>Gets all relations of the TestNotPerformedEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUpdatedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.TestNotPerformedReasonEntityUsingTestNotPerformedReasonId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between TestNotPerformedEntity and CustomerEventScreeningTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// TestNotPerformed.CustomerEventScreeningTestId - CustomerEventScreeningTests.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventScreeningTests", false);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, TestNotPerformedFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestNotPerformedEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestNotPerformedEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// TestNotPerformed.UpdatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestNotPerformedFields.UpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestNotPerformedEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestNotPerformedEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// TestNotPerformed.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestNotPerformedFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestNotPerformedEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestNotPerformedEntity and TestNotPerformedReasonEntity over the m:1 relation they have, using the relation between the fields:
		/// TestNotPerformed.TestNotPerformedReasonId - TestNotPerformedReason.Id
		/// </summary>
		public virtual IEntityRelation TestNotPerformedReasonEntityUsingTestNotPerformedReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TestNotPerformedReason", false);
				relation.AddEntityFieldPair(TestNotPerformedReasonFields.Id, TestNotPerformedFields.TestNotPerformedReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestNotPerformedReasonEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestNotPerformedEntity", true);
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
