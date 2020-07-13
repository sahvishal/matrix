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
	/// <summary>Implements the static Relations variant for the entity: AfimpressionLog. </summary>
	public partial class AfimpressionLogRelations
	{
		/// <summary>CTor</summary>
		public AfimpressionLogRelations()
		{
		}

		/// <summary>Gets all relations of the AfimpressionLogEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AfaffiliateCampaignMarketingMaterialEntityUsingAffiliateCampaignMarketingMaterialId);
			toReturn.Add(this.AfcampaignEntityUsingAffiliateCampaignMarketingMaterialId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AfimpressionLogEntity and AfaffiliateCampaignMarketingMaterialEntity over the m:1 relation they have, using the relation between the fields:
		/// AfimpressionLog.AffiliateCampaignMarketingMaterialId - AfaffiliateCampaignMarketingMaterial.AffiliateCampaignMarketingMaterialId
		/// </summary>
		public virtual IEntityRelation AfaffiliateCampaignMarketingMaterialEntityUsingAffiliateCampaignMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfaffiliateCampaignMarketingMaterial", false);
				relation.AddEntityFieldPair(AfaffiliateCampaignMarketingMaterialFields.AffiliateCampaignMarketingMaterialId, AfimpressionLogFields.AffiliateCampaignMarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignMarketingMaterialEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfimpressionLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AfimpressionLogEntity and AfcampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// AfimpressionLog.AffiliateCampaignMarketingMaterialId - Afcampaign.CampaignId
		/// </summary>
		public virtual IEntityRelation AfcampaignEntityUsingAffiliateCampaignMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Afcampaign", false);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, AfimpressionLogFields.AffiliateCampaignMarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfimpressionLogEntity", true);
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
