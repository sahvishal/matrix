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
	/// <summary>Implements the static Relations variant for the entity: Role. </summary>
	public partial class RoleRelations
	{
		/// <summary>CTor</summary>
		public RoleRelations()
		{
		}

		/// <summary>Gets all relations of the RoleEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ContactsEntityUsingModifiedRoleId);
			toReturn.Add(this.ContactsEntityUsingAddedRoleId);
			toReturn.Add(this.CustomerProfileEntityUsingAddedByRoleId);
			toReturn.Add(this.HostFacilityRankingEntityUsingRankedByRole);
			toReturn.Add(this.OrganizationRoleUserEntityUsingRoleId);
			toReturn.Add(this.RoleEntityUsingParentId);
			toReturn.Add(this.RoleAccessControlObjectEntityUsingRoleId);
			toReturn.Add(this.RolePermisibleAccessControlObjectEntityUsingRoleId);
			toReturn.Add(this.RoleScopeOptionEntityUsingRoleId);
			toReturn.Add(this.UserEntityUsingDefaultRoleId);

			toReturn.Add(this.OrganizationTypeEntityUsingOrganizationTypeId);
			toReturn.Add(this.RoleEntityUsingRoleIdParentId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and ContactsEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - Contacts.ModifiedRoleId
		/// </summary>
		public virtual IEntityRelation ContactsEntityUsingModifiedRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Contacts_" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, ContactsFields.ModifiedRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and ContactsEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - Contacts.AddedRoleId
		/// </summary>
		public virtual IEntityRelation ContactsEntityUsingAddedRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Contacts" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, ContactsFields.AddedRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - CustomerProfile.AddedByRoleId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingAddedByRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, CustomerProfileFields.AddedByRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and HostFacilityRankingEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - HostFacilityRanking.RankedByRole
		/// </summary>
		public virtual IEntityRelation HostFacilityRankingEntityUsingRankedByRole
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostFacilityRanking" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, HostFacilityRankingFields.RankedByRole);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and OrganizationRoleUserEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - OrganizationRoleUser.RoleId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrganizationRoleUser" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, OrganizationRoleUserFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and RoleEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - Role.ParentId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Role_" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, RoleFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and RoleAccessControlObjectEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - RoleAccessControlObject.RoleId
		/// </summary>
		public virtual IEntityRelation RoleAccessControlObjectEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleAccessControlObject" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, RoleAccessControlObjectFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAccessControlObjectEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and RolePermisibleAccessControlObjectEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - RolePermisibleAccessControlObject.RoleId
		/// </summary>
		public virtual IEntityRelation RolePermisibleAccessControlObjectEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RolePermisibleAccessControlObject" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, RolePermisibleAccessControlObjectFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RolePermisibleAccessControlObjectEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and RoleScopeOptionEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - RoleScopeOption.RoleId
		/// </summary>
		public virtual IEntityRelation RoleScopeOptionEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleScopeOption" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, RoleScopeOptionFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleScopeOptionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and UserEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - User.DefaultRoleId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingDefaultRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "User" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, UserFields.DefaultRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between RoleEntity and OrganizationTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Role.OrganizationTypeId - OrganizationType.OrganizationTypeId
		/// </summary>
		public virtual IEntityRelation OrganizationTypeEntityUsingOrganizationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationType", false);
				relation.AddEntityFieldPair(OrganizationTypeFields.OrganizationTypeId, RoleFields.OrganizationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RoleEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// Role.ParentId - Role.RoleId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingRoleIdParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role", false);
				relation.AddEntityFieldPair(RoleFields.RoleId, RoleFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
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
