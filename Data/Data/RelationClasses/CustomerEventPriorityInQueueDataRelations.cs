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
	/// <summary>Implements the static Relations variant for the entity: CustomerEventPriorityInQueueData. </summary>
	public partial class CustomerEventPriorityInQueueDataRelations
	{
		/// <summary>CTor</summary>
		public CustomerEventPriorityInQueueDataRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerEventPriorityInQueueDataEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between CustomerEventPriorityInQueueDataEntity and CustomerEventScreeningTestsEntity over the 1:1 relation they have, using the relation between the fields:
		/// CustomerEventPriorityInQueueData.CustomerEventScreeningTestId - CustomerEventScreeningTests.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CustomerEventScreeningTests", false);



				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventPriorityInQueueDataFields.CustomerEventScreeningTestId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventPriorityInQueueDataEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEventPriorityInQueueDataEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventPriorityInQueueData.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventPriorityInQueueDataFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventPriorityInQueueDataEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerEventPriorityInQueueDataEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventPriorityInQueueData.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventPriorityInQueueDataFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventPriorityInQueueDataEntity", true);
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
