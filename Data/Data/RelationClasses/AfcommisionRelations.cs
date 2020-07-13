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
	/// <summary>Implements the static Relations variant for the entity: Afcommision. </summary>
	public partial class AfcommisionRelations
	{
		/// <summary>CTor</summary>
		public AfcommisionRelations()
		{
		}

		/// <summary>Gets all relations of the AfcommisionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AfaffiliateCampaignEntityUsingAffiliateCampaignId);
			toReturn.Add(this.AffiliateProfileEntityUsingAffiliateId);
			toReturn.Add(this.AfpaymentEntityUsingPaymentId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AfcommisionEntity and AfaffiliateCampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// Afcommision.AffiliateCampaignId - AfaffiliateCampaign.AffiliateCampaignId
		/// </summary>
		public virtual IEntityRelation AfaffiliateCampaignEntityUsingAffiliateCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfaffiliateCampaign", false);
				relation.AddEntityFieldPair(AfaffiliateCampaignFields.AffiliateCampaignId, AfcommisionFields.AffiliateCampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcommisionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AfcommisionEntity and AffiliateProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// Afcommision.AffiliateId - AffiliateProfile.AffiliateId
		/// </summary>
		public virtual IEntityRelation AffiliateProfileEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AffiliateProfile", false);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfcommisionFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcommisionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AfcommisionEntity and AfpaymentEntity over the m:1 relation they have, using the relation between the fields:
		/// Afcommision.PaymentId - Afpayment.PaymentId
		/// </summary>
		public virtual IEntityRelation AfpaymentEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Afpayment", false);
				relation.AddEntityFieldPair(AfpaymentFields.PaymentId, AfcommisionFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfpaymentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcommisionEntity", true);
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
