﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: CustomCampaignContent. </summary>
	public partial class CustomCampaignContentRelations
	{
		/// <summary>CTor</summary>
		public CustomCampaignContentRelations()
		{
		}

		/// <summary>Gets all relations of the CustomCampaignContentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AfcampaignEntityUsingCampaignId);
			toReturn.Add(this.AfmarketingMaterialEntityUsingMarketingMaterialId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CustomCampaignContentEntity and AfcampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomCampaignContent.CampaignId - Afcampaign.CampaignId
		/// </summary>
		public virtual IEntityRelation AfcampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Afcampaign", false);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, CustomCampaignContentFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomCampaignContentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomCampaignContentEntity and AfmarketingMaterialEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomCampaignContent.MarketingMaterialId - AfmarketingMaterial.MarketingMaterialId
		/// </summary>
		public virtual IEntityRelation AfmarketingMaterialEntityUsingMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfmarketingMaterial", false);
				relation.AddEntityFieldPair(AfmarketingMaterialFields.MarketingMaterialId, CustomCampaignContentFields.MarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomCampaignContentEntity", true);
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
