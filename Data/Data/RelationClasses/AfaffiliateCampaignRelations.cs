///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
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
	/// <summary>Implements the static Relations variant for the entity: AfaffiliateCampaign. </summary>
	public partial class AfaffiliateCampaignRelations
	{
		/// <summary>CTor</summary>
		public AfaffiliateCampaignRelations()
		{
		}

		/// <summary>Gets all relations of the AfaffiliateCampaignEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfcommisionEntityUsingAffiliateCampaignId);
			toReturn.Add(this.EventCustomersEntityUsingAffiliateCampaignId);

			toReturn.Add(this.AfcampaignEntityUsingCampaignId);
			toReturn.Add(this.AffiliateProfileEntityUsingAffiliateId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AfaffiliateCampaignEntity and AfcommisionEntity over the 1:n relation they have, using the relation between the fields:
		/// AfaffiliateCampaign.AffiliateCampaignId - Afcommision.AffiliateCampaignId
		/// </summary>
		public virtual IEntityRelation AfcommisionEntityUsingAffiliateCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afcommision" , true);
				relation.AddEntityFieldPair(AfaffiliateCampaignFields.AffiliateCampaignId, AfcommisionFields.AffiliateCampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcommisionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfaffiliateCampaignEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// AfaffiliateCampaign.AffiliateCampaignId - EventCustomers.AffiliateCampaignId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingAffiliateCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers" , true);
				relation.AddEntityFieldPair(AfaffiliateCampaignFields.AffiliateCampaignId, EventCustomersFields.AffiliateCampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AfaffiliateCampaignEntity and AfcampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// AfaffiliateCampaign.CampaignId - Afcampaign.CampaignId
		/// </summary>
		public virtual IEntityRelation AfcampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Afcampaign", false);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, AfaffiliateCampaignFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AfaffiliateCampaignEntity and AffiliateProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// AfaffiliateCampaign.AffiliateId - AffiliateProfile.AffiliateId
		/// </summary>
		public virtual IEntityRelation AffiliateProfileEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AffiliateProfile", false);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfaffiliateCampaignFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignEntity", true);
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
