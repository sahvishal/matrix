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
	/// <summary>Implements the static Relations variant for the entity: AfcampaignSubAdvocate. </summary>
	public partial class AfcampaignSubAdvocateRelations
	{
		/// <summary>CTor</summary>
		public AfcampaignSubAdvocateRelations()
		{
		}

		/// <summary>Gets all relations of the AfcampaignSubAdvocateEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.AffiliateProfileEntityUsingCampaignSubAffiliateId);
			toReturn.Add(this.AfcampaignEntityUsingCampaignId);
			toReturn.Add(this.AffiliateProfileEntityUsingAffiliateId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between AfcampaignSubAdvocateEntity and AffiliateProfileEntity over the 1:1 relation they have, using the relation between the fields:
		/// AfcampaignSubAdvocate.CampaignSubAffiliateId - AffiliateProfile.AffiliateId
		/// </summary>
		public virtual IEntityRelation AffiliateProfileEntityUsingCampaignSubAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "AffiliateProfile_", false);



				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfcampaignSubAdvocateFields.CampaignSubAffiliateId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignSubAdvocateEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignSubAdvocateEntity and AfcampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// AfcampaignSubAdvocate.CampaignId - Afcampaign.CampaignId
		/// </summary>
		public virtual IEntityRelation AfcampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Afcampaign", false);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, AfcampaignSubAdvocateFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignSubAdvocateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AfcampaignSubAdvocateEntity and AffiliateProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// AfcampaignSubAdvocate.AffiliateId - AffiliateProfile.AffiliateId
		/// </summary>
		public virtual IEntityRelation AffiliateProfileEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AffiliateProfile", false);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfcampaignSubAdvocateFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignSubAdvocateEntity", true);
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
