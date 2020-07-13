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
	/// <summary>Implements the static Relations variant for the entity: ShippingDetail. </summary>
	public partial class ShippingDetailRelations
	{
		/// <summary>CTor</summary>
		public ShippingDetailRelations()
		{
		}

		/// <summary>Gets all relations of the ShippingDetailEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ShippingDetailOrderDetailEntityUsingShippingDetailId);

			toReturn.Add(this.AddressEntityUsingShippingAddressId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingShippedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedBy);
			toReturn.Add(this.ShippingOptionEntityUsingShippingOptionId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ShippingDetailEntity and ShippingDetailOrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// ShippingDetail.ShippingDetailId - ShippingDetailOrderDetail.ShippingDetailId
		/// </summary>
		public virtual IEntityRelation ShippingDetailOrderDetailEntityUsingShippingDetailId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingDetailOrderDetail" , true);
				relation.AddEntityFieldPair(ShippingDetailFields.ShippingDetailId, ShippingDetailOrderDetailFields.ShippingDetailId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailOrderDetailEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ShippingDetailEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// ShippingDetail.ShippingAddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingShippingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, ShippingDetailFields.ShippingAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ShippingDetailEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// ShippingDetail.ShippedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingShippedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ShippingDetailFields.ShippedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ShippingDetailEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// ShippingDetail.ModifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ShippingDetailFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ShippingDetailEntity and ShippingOptionEntity over the m:1 relation they have, using the relation between the fields:
		/// ShippingDetail.ShippingOptionId - ShippingOption.ShippingOptionId
		/// </summary>
		public virtual IEntityRelation ShippingOptionEntityUsingShippingOptionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShippingOption", false);
				relation.AddEntityFieldPair(ShippingOptionFields.ShippingOptionId, ShippingDetailFields.ShippingOptionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", true);
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
