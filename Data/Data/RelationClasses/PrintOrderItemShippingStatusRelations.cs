///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Tuesday, March 23, 2010 5:19:10 AM
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
	/// <summary>Implements the static Relations variant for the entity: PrintOrderItemShippingStatus. </summary>
	public partial class PrintOrderItemShippingStatusRelations
	{
		/// <summary>CTor</summary>
		public PrintOrderItemShippingStatusRelations()
		{
		}

		/// <summary>Gets all relations of the PrintOrderItemShippingStatusEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.LookupEntityUsingStatus);
			toReturn.Add(this.LookupEntityUsingConfirmationMode);
			toReturn.Add(this.MarketingPrintOrderItemEntityUsingPrintOrderItemId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemShippingStatusEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemShippingStatus.Status - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PrintOrderItemShippingStatusFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemShippingStatusEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemShippingStatusEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemShippingStatus.ConfirmationMode - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingConfirmationMode
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PrintOrderItemShippingStatusFields.ConfirmationMode);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemShippingStatusEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemShippingStatusEntity and MarketingPrintOrderItemEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemShippingStatus.PrintOrderItemId - MarketingPrintOrderItem.MarketingPrintOrderItemId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderItemEntityUsingPrintOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MarketingPrintOrderItem", false);
				relation.AddEntityFieldPair(MarketingPrintOrderItemFields.MarketingPrintOrderItemId, PrintOrderItemShippingStatusFields.PrintOrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemShippingStatusEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintOrderItemShippingStatusEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintOrderItemShippingStatus.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PrintOrderItemShippingStatusFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemShippingStatusEntity", true);
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
