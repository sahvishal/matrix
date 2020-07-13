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
	/// <summary>Implements the static Relations variant for the entity: MarketingPrintOrder. </summary>
	public partial class MarketingPrintOrderRelations
	{
		/// <summary>CTor</summary>
		public MarketingPrintOrderRelations()
		{
		}

		/// <summary>Gets all relations of the MarketingPrintOrderEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.MarketingPrintOrderEventMappingEntityUsingMarketingPrintOrderId);
			toReturn.Add(this.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId);

			toReturn.Add(this.OrganizationEntityUsingPrintVendorOrganizationId);
			toReturn.Add(this.OrganizationEntityUsingFranchiseeOrganizationId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderEntity and MarketingPrintOrderEventMappingEntity over the 1:n relation they have, using the relation between the fields:
		/// MarketingPrintOrder.MarketingPrintOrderId - MarketingPrintOrderEventMapping.MarketingPrintOrderId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderEventMappingEntityUsingMarketingPrintOrderId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrderEventMapping" , true);
				relation.AddEntityFieldPair(MarketingPrintOrderFields.MarketingPrintOrderId, MarketingPrintOrderEventMappingFields.MarketingPrintOrderId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEventMappingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderEntity and MarketingPrintOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// MarketingPrintOrder.MarketingPrintOrderId - MarketingPrintOrderItem.MarketingPrintOrderId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderItemEntityUsingMarketingPrintOrderId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrderItem" , true);
				relation.AddEntityFieldPair(MarketingPrintOrderFields.MarketingPrintOrderId, MarketingPrintOrderItemFields.MarketingPrintOrderId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// MarketingPrintOrder.PrintVendorOrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingPrintVendorOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization_", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, MarketingPrintOrderFields.PrintVendorOrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// MarketingPrintOrder.FranchiseeOrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingFranchiseeOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, MarketingPrintOrderFields.FranchiseeOrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// MarketingPrintOrder.OrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, MarketingPrintOrderFields.OrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEntity", true);
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
