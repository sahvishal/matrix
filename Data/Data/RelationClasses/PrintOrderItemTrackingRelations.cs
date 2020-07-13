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
	/// <summary>Implements the static Relations variant for the entity: PrintOrderItemTracking. </summary>
	public partial class PrintOrderItemTrackingRelations
	{
		/// <summary>CTor</summary>
		public PrintOrderItemTrackingRelations()
		{
		}

		/// <summary>Gets all relations of the PrintOrderItemTrackingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.LookupEntityUsingConfirmationMode);
			toReturn.Add(this.MarketingPrintOrderItemEntityUsingPrintOrderItemId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemTrackingEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemTracking.ConfirmationMode - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingConfirmationMode
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PrintOrderItemTrackingFields.ConfirmationMode);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemTrackingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemTrackingEntity and MarketingPrintOrderItemEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemTracking.PrintOrderItemId - MarketingPrintOrderItem.MarketingPrintOrderItemId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderItemEntityUsingPrintOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MarketingPrintOrderItem", false);
				relation.AddEntityFieldPair(MarketingPrintOrderItemFields.MarketingPrintOrderItemId, PrintOrderItemTrackingFields.PrintOrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemTrackingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemTrackingEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemTracking.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PrintOrderItemTrackingFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemTrackingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemTrackingEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemTracking.UpdatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PrintOrderItemTrackingFields.UpdatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemTrackingEntity", true);
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
