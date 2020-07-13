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
	/// <summary>Implements the static Relations variant for the entity: ClickLog. </summary>
	public partial class ClickLogRelations
	{
		/// <summary>CTor</summary>
		public ClickLogRelations()
		{
		}

		/// <summary>Gets all relations of the ClickLogEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ClickConversionEntityUsingClickId);
			toReturn.Add(this.ClickKeywordEntityUsingClickId);

			toReturn.Add(this.AfcampaignEntityUsingCampaignId);
			toReturn.Add(this.AfmarketingMaterialEntityUsingMarketingMaterialId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ClickLogEntity and ClickConversionEntity over the 1:n relation they have, using the relation between the fields:
		/// ClickLog.ClickId - ClickConversion.ClickId
		/// </summary>
		public virtual IEntityRelation ClickConversionEntityUsingClickId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClickConversion" , true);
				relation.AddEntityFieldPair(ClickLogFields.ClickId, ClickConversionFields.ClickId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickLogEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickConversionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ClickLogEntity and ClickKeywordEntity over the 1:n relation they have, using the relation between the fields:
		/// ClickLog.ClickId - ClickKeyword.ClickId
		/// </summary>
		public virtual IEntityRelation ClickKeywordEntityUsingClickId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClickKeyword" , true);
				relation.AddEntityFieldPair(ClickLogFields.ClickId, ClickKeywordFields.ClickId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickLogEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickKeywordEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ClickLogEntity and AfcampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// ClickLog.CampaignId - Afcampaign.CampaignId
		/// </summary>
		public virtual IEntityRelation AfcampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Afcampaign", false);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, ClickLogFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ClickLogEntity and AfmarketingMaterialEntity over the m:1 relation they have, using the relation between the fields:
		/// ClickLog.MarketingMaterialId - AfmarketingMaterial.MarketingMaterialId
		/// </summary>
		public virtual IEntityRelation AfmarketingMaterialEntityUsingMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfmarketingMaterial", false);
				relation.AddEntityFieldPair(AfmarketingMaterialFields.MarketingMaterialId, ClickLogFields.MarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickLogEntity", true);
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
