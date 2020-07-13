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
	/// <summary>Implements the static Relations variant for the entity: TestHcpcsCode. </summary>
	public partial class TestHcpcsCodeRelations
	{
		/// <summary>CTor</summary>
		public TestHcpcsCodeRelations()
		{
		}

		/// <summary>Gets all relations of the TestHcpcsCodeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountTestHcpcsCodeEntityUsingTestHcpcsCodeId);
			toReturn.Add(this.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId);

			toReturn.Add(this.HcpcsCodeEntityUsingHcpcsCodeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TestHcpcsCodeEntity and AccountTestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// TestHcpcsCode.Id - AccountTestHcpcsCode.TestHcpcsCodeId
		/// </summary>
		public virtual IEntityRelation AccountTestHcpcsCodeEntityUsingTestHcpcsCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountTestHcpcsCode" , true);
				relation.AddEntityFieldPair(TestHcpcsCodeFields.Id, AccountTestHcpcsCodeFields.TestHcpcsCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountTestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TestHcpcsCodeEntity and EventAccountTestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// TestHcpcsCode.Id - EventAccountTestHcpcsCode.TestHcpcsCodeId
		/// </summary>
		public virtual IEntityRelation EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAccountTestHcpcsCode" , true);
				relation.AddEntityFieldPair(TestHcpcsCodeFields.Id, EventAccountTestHcpcsCodeFields.TestHcpcsCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TestHcpcsCodeEntity and HcpcsCodeEntity over the m:1 relation they have, using the relation between the fields:
		/// TestHcpcsCode.HcpcsCodeId - HcpcsCode.Id
		/// </summary>
		public virtual IEntityRelation HcpcsCodeEntityUsingHcpcsCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HcpcsCode", false);
				relation.AddEntityFieldPair(HcpcsCodeFields.Id, TestHcpcsCodeFields.HcpcsCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HcpcsCodeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestHcpcsCodeEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// TestHcpcsCode.ModifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestHcpcsCodeFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestHcpcsCodeEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// TestHcpcsCode.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestHcpcsCodeFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestHcpcsCodeEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// TestHcpcsCode.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, TestHcpcsCodeFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", true);
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
