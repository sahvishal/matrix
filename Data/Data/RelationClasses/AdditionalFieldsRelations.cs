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
	/// <summary>Implements the static Relations variant for the entity: AdditionalFields. </summary>
	public partial class AdditionalFieldsRelations
	{
		/// <summary>CTor</summary>
		public AdditionalFieldsRelations()
		{
		}

		/// <summary>Gets all relations of the AdditionalFieldsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountAdditionalFieldsEntityUsingAdditionalFieldId);

			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AdditionalFieldsEntity and AccountAdditionalFieldsEntity over the 1:n relation they have, using the relation between the fields:
		/// AdditionalFields.Id - AccountAdditionalFields.AdditionalFieldId
		/// </summary>
		public virtual IEntityRelation AccountAdditionalFieldsEntityUsingAdditionalFieldId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountAdditionalFields" , true);
				relation.AddEntityFieldPair(AdditionalFieldsFields.Id, AccountAdditionalFieldsFields.AdditionalFieldId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AdditionalFieldsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountAdditionalFieldsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AdditionalFieldsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// AdditionalFields.ModifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AdditionalFieldsFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AdditionalFieldsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AdditionalFieldsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// AdditionalFields.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AdditionalFieldsFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AdditionalFieldsEntity", true);
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
