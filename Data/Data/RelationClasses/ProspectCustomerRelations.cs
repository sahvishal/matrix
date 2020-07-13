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
	/// <summary>Implements the static Relations variant for the entity: ProspectCustomer. </summary>
	public partial class ProspectCustomerRelations
	{
		/// <summary>CTor</summary>
		public ProspectCustomerRelations()
		{
		}

		/// <summary>Gets all relations of the ProspectCustomerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallQueueCustomerEntityUsingProspectCustomerId);
			toReturn.Add(this.ClickConversionEntityUsingProspectCustomerId);
			toReturn.Add(this.ProspectCustomerCallEntityUsingProspectCustomerId);
			toReturn.Add(this.ProspectCustomerNotificationEntityUsingProspectCustomerId);
			toReturn.Add(this.TempCartEntityUsingProspectCustomerId);

			toReturn.Add(this.AfaffiliateCampaignMarketingMaterialEntityUsingAffiliateCampaignMarketingMaterialId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.LookupEntityUsingSource);
			toReturn.Add(this.OrganizationRoleUserEntityUsingContactedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// ProspectCustomer.ProspectCustomerId - CallQueueCustomer.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, CallQueueCustomerFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerEntity and ClickConversionEntity over the 1:n relation they have, using the relation between the fields:
		/// ProspectCustomer.ProspectCustomerId - ClickConversion.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation ClickConversionEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClickConversion" , true);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, ClickConversionFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickConversionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerEntity and ProspectCustomerCallEntity over the 1:n relation they have, using the relation between the fields:
		/// ProspectCustomer.ProspectCustomerId - ProspectCustomerCall.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerCallEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectCustomerCall" , true);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, ProspectCustomerCallFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerEntity and ProspectCustomerNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// ProspectCustomer.ProspectCustomerId - ProspectCustomerNotification.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerNotificationEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectCustomerNotification" , true);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, ProspectCustomerNotificationFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerEntity and TempCartEntity over the 1:n relation they have, using the relation between the fields:
		/// ProspectCustomer.ProspectCustomerId - TempCart.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation TempCartEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TempCart" , true);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, TempCartFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerEntity and AfaffiliateCampaignMarketingMaterialEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectCustomer.AffiliateCampaignMarketingMaterialId - AfaffiliateCampaignMarketingMaterial.AffiliateCampaignMarketingMaterialId
		/// </summary>
		public virtual IEntityRelation AfaffiliateCampaignMarketingMaterialEntityUsingAffiliateCampaignMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfaffiliateCampaignMarketingMaterial", false);
				relation.AddEntityFieldPair(AfaffiliateCampaignMarketingMaterialFields.AffiliateCampaignMarketingMaterialId, ProspectCustomerFields.AffiliateCampaignMarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignMarketingMaterialEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectCustomer.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, ProspectCustomerFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectCustomer.Source - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, ProspectCustomerFields.Source);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectCustomer.ContactedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingContactedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ProspectCustomerFields.ContactedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", true);
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
