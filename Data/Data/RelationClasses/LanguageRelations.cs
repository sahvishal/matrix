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
	/// <summary>Implements the static Relations variant for the entity: Language. </summary>
	public partial class LanguageRelations
	{
		/// <summary>CTor</summary>
		public LanguageRelations()
		{
		}

		/// <summary>Gets all relations of the LanguageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallQueueCustomerEntityUsingLanguageId);
			toReturn.Add(this.CustomerProfileEntityUsingLanguageId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingLanguageId);

			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between LanguageEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// Language.Id - CallQueueCustomer.LanguageId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingLanguageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(LanguageFields.Id, CallQueueCustomerFields.LanguageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LanguageEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Language.Id - CustomerProfile.LanguageId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingLanguageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile" , true);
				relation.AddEntityFieldPair(LanguageFields.Id, CustomerProfileFields.LanguageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LanguageEntity and HealthPlanCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// Language.Id - HealthPlanCallQueueCriteria.LanguageId
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingLanguageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCallQueueCriteria" , true);
				relation.AddEntityFieldPair(LanguageFields.Id, HealthPlanCallQueueCriteriaFields.LanguageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between LanguageEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Language.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, LanguageFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageEntity", true);
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
