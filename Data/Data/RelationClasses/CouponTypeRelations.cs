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
	/// <summary>Implements the static Relations variant for the entity: CouponType. </summary>
	public partial class CouponTypeRelations
	{
		/// <summary>CTor</summary>
		public CouponTypeRelations()
		{
		}

		/// <summary>Gets all relations of the CouponTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CouponsEntityUsingCouponTypeId);
			toReturn.Add(this.MarketingOffersEntityUsingMarketingOfferTypeId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CouponTypeEntity and CouponsEntity over the 1:n relation they have, using the relation between the fields:
		/// CouponType.CouponTypeId - Coupons.CouponTypeId
		/// </summary>
		public virtual IEntityRelation CouponsEntityUsingCouponTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Coupons" , true);
				relation.AddEntityFieldPair(CouponTypeFields.CouponTypeId, CouponsFields.CouponTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouponTypeEntity and MarketingOffersEntity over the 1:n relation they have, using the relation between the fields:
		/// CouponType.CouponTypeId - MarketingOffers.MarketingOfferTypeId
		/// </summary>
		public virtual IEntityRelation MarketingOffersEntityUsingMarketingOfferTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingOffers" , true);
				relation.AddEntityFieldPair(CouponTypeFields.CouponTypeId, MarketingOffersFields.MarketingOfferTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingOffersEntity", false);
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
