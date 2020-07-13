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
	/// <summary>Implements the static Relations variant for the entity: User. </summary>
	public partial class UserRelations
	{
		/// <summary>CTor</summary>
		public UserRelations()
		{
		}

		/// <summary>Gets all relations of the UserEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrganizationRoleUserEntityUsingUserId);
			toReturn.Add(this.SystemUserInfoEntityUsingUserId);
			toReturn.Add(this.UserLoginEntityUsingUserLoginId);
			toReturn.Add(this.UserNpiInfoEntityUsingUserId);
			toReturn.Add(this.AddressEntityUsingHomeAddressId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.RoleEntityUsingDefaultRoleId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between UserEntity and OrganizationRoleUserEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - OrganizationRoleUser.UserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrganizationRoleUser" , true);
				relation.AddEntityFieldPair(UserFields.UserId, OrganizationRoleUserFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and SystemUserInfoEntity over the 1:1 relation they have, using the relation between the fields:
		/// User.UserId - SystemUserInfo.UserId
		/// </summary>
		public virtual IEntityRelation SystemUserInfoEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "SystemUserInfo", true);

				relation.AddEntityFieldPair(UserFields.UserId, SystemUserInfoFields.UserId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemUserInfoEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserLoginEntity over the 1:1 relation they have, using the relation between the fields:
		/// User.UserId - UserLogin.UserLoginId
		/// </summary>
		public virtual IEntityRelation UserLoginEntityUsingUserLoginId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "UserLogin", true);

				relation.AddEntityFieldPair(UserFields.UserId, UserLoginFields.UserLoginId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserLoginEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserNpiInfoEntity over the 1:1 relation they have, using the relation between the fields:
		/// User.UserId - UserNpiInfo.UserId
		/// </summary>
		public virtual IEntityRelation UserNpiInfoEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "UserNpiInfo", true);

				relation.AddEntityFieldPair(UserFields.UserId, UserNpiInfoFields.UserId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserNpiInfoEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// User.HomeAddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingHomeAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, UserFields.HomeAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between UserEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// User.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser__", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, UserFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between UserEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// User.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, UserFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between UserEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// User.DefaultRoleId - Role.RoleId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingDefaultRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role", false);
				relation.AddEntityFieldPair(RoleFields.RoleId, UserFields.DefaultRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
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
