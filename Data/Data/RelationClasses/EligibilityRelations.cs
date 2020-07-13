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
	/// <summary>Implements the static Relations variant for the entity: Eligibility. </summary>
	public partial class EligibilityRelations
	{
		/// <summary>CTor</summary>
		public EligibilityRelations()
		{
		}

		/// <summary>Gets all relations of the EligibilityEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventCustomerEligibilityEntityUsingEligibilityId);
			toReturn.Add(this.TempCartEntityUsingEligibilityId);

			toReturn.Add(this.InsuranceCompanyEntityUsingInsuranceCompanyId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EligibilityEntity and EventCustomerEligibilityEntity over the 1:n relation they have, using the relation between the fields:
		/// Eligibility.EligibilityId - EventCustomerEligibility.EligibilityId
		/// </summary>
		public virtual IEntityRelation EventCustomerEligibilityEntityUsingEligibilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerEligibility" , true);
				relation.AddEntityFieldPair(EligibilityFields.EligibilityId, EventCustomerEligibilityFields.EligibilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerEligibilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EligibilityEntity and TempCartEntity over the 1:n relation they have, using the relation between the fields:
		/// Eligibility.EligibilityId - TempCart.EligibilityId
		/// </summary>
		public virtual IEntityRelation TempCartEntityUsingEligibilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TempCart" , true);
				relation.AddEntityFieldPair(EligibilityFields.EligibilityId, TempCartFields.EligibilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between EligibilityEntity and InsuranceCompanyEntity over the m:1 relation they have, using the relation between the fields:
		/// Eligibility.InsuranceCompanyId - InsuranceCompany.InsuranceCompanyId
		/// </summary>
		public virtual IEntityRelation InsuranceCompanyEntityUsingInsuranceCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "InsuranceCompany", false);
				relation.AddEntityFieldPair(InsuranceCompanyFields.InsuranceCompanyId, EligibilityFields.InsuranceCompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InsuranceCompanyEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EligibilityEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Eligibility.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EligibilityFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityEntity", true);
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
