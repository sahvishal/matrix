///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Tuesday, March 23, 2010 9:25:45 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: PrintOrderItemShipping. </summary>
	public partial class PrintOrderItemShippingRelations
	{
		/// <summary>CTor</summary>
		public PrintOrderItemShippingRelations()
		{
		}

		/// <summary>Gets all relations of the PrintOrderItemShippingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.LookupEntityUsingConfirmationMode);
			toReturn.Add(this.LookupEntityUsingShippingStatus);
			toReturn.Add(this.MarketingPrintOrderItemEntityUsingPrintOrderItemId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemShippingEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemShipping.ConfirmationMode - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingConfirmationMode
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PrintOrderItemShippingFields.ConfirmationMode);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemShippingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemShippingEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemShipping.ShippingStatus - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingShippingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PrintOrderItemShippingFields.ShippingStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemShippingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemShippingEntity and MarketingPrintOrderItemEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemShipping.PrintOrderItemId - MarketingPrintOrderItem.MarketingPrintOrderItemId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderItemEntityUsingPrintOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MarketingPrintOrderItem", false);
				relation.AddEntityFieldPair(MarketingPrintOrderItemFields.MarketingPrintOrderItemId, PrintOrderItemShippingFields.PrintOrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemShippingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemShippingEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemShipping.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PrintOrderItemShippingFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemShippingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemShippingEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemShipping.UpdatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PrintOrderItemShippingFields.UpdatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemShippingEntity", true);
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
