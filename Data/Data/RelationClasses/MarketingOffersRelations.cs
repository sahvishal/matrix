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
	/// <summary>Implements the static Relations variant for the entity: MarketingOffers. </summary>
	public partial class MarketingOffersRelations
	{
		/// <summary>CTor</summary>
		public MarketingOffersRelations()
		{
		}

		/// <summary>Gets all relations of the MarketingOffersEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventMarketingOffersEntityUsingMarketingOfferId);

			toReturn.Add(this.CouponTypeEntityUsingMarketingOfferTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MarketingOffersEntity and EventMarketingOffersEntity over the 1:n relation they have, using the relation between the fields:
		/// MarketingOffers.MarketingOfferId - EventMarketingOffers.MarketingOfferId
		/// </summary>
		public virtual IEntityRelation EventMarketingOffersEntityUsingMarketingOfferId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventMarketingOffers" , true);
				relation.AddEntityFieldPair(MarketingOffersFields.MarketingOfferId, EventMarketingOffersFields.MarketingOfferId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingOffersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventMarketingOffersEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between MarketingOffersEntity and CouponTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// MarketingOffers.MarketingOfferTypeId - CouponType.CouponTypeId
		/// </summary>
		public virtual IEntityRelation CouponTypeEntityUsingMarketingOfferTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CouponType", false);
				relation.AddEntityFieldPair(CouponTypeFields.CouponTypeId, MarketingOffersFields.MarketingOfferTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingOffersEntity", true);
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
