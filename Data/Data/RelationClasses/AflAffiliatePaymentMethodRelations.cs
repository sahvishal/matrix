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
	/// <summary>Implements the static Relations variant for the entity: AflAffiliatePaymentMethod. </summary>
	public partial class AflAffiliatePaymentMethodRelations
	{
		/// <summary>CTor</summary>
		public AflAffiliatePaymentMethodRelations()
		{
		}

		/// <summary>Gets all relations of the AflAffiliatePaymentMethodEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfmanualCheckEntityUsingAffiliatePaymentMethodId);
			toReturn.Add(this.AfpaypalEntityUsingAffiliatePaymentMethod);

			toReturn.Add(this.AffiliateProfileEntityUsingAffiliateId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AflAffiliatePaymentMethodEntity and AfmanualCheckEntity over the 1:n relation they have, using the relation between the fields:
		/// AflAffiliatePaymentMethod.AffiliatePaymentMethod - AfmanualCheck.AffiliatePaymentMethodId
		/// </summary>
		public virtual IEntityRelation AfmanualCheckEntityUsingAffiliatePaymentMethodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfmanualCheck" , true);
				relation.AddEntityFieldPair(AflAffiliatePaymentMethodFields.AffiliatePaymentMethod, AfmanualCheckFields.AffiliatePaymentMethodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AflAffiliatePaymentMethodEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmanualCheckEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AflAffiliatePaymentMethodEntity and AfpaypalEntity over the 1:n relation they have, using the relation between the fields:
		/// AflAffiliatePaymentMethod.AffiliatePaymentMethod - Afpaypal.AffiliatePaymentMethod
		/// </summary>
		public virtual IEntityRelation AfpaypalEntityUsingAffiliatePaymentMethod
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afpaypal" , true);
				relation.AddEntityFieldPair(AflAffiliatePaymentMethodFields.AffiliatePaymentMethod, AfpaypalFields.AffiliatePaymentMethod);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AflAffiliatePaymentMethodEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfpaypalEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AflAffiliatePaymentMethodEntity and AffiliateProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// AflAffiliatePaymentMethod.AffiliateId - AffiliateProfile.AffiliateId
		/// </summary>
		public virtual IEntityRelation AffiliateProfileEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AffiliateProfile", false);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AflAffiliatePaymentMethodFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AflAffiliatePaymentMethodEntity", true);
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
