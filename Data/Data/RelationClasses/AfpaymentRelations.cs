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
	/// <summary>Implements the static Relations variant for the entity: Afpayment. </summary>
	public partial class AfpaymentRelations
	{
		/// <summary>CTor</summary>
		public AfpaymentRelations()
		{
		}

		/// <summary>Gets all relations of the AfpaymentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfcommisionEntityUsingPaymentId);

			toReturn.Add(this.AffiliateProfileEntityUsingAffiliateId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AfpaymentEntity and AfcommisionEntity over the 1:n relation they have, using the relation between the fields:
		/// Afpayment.PaymentId - Afcommision.PaymentId
		/// </summary>
		public virtual IEntityRelation AfcommisionEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afcommision" , true);
				relation.AddEntityFieldPair(AfpaymentFields.PaymentId, AfcommisionFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfpaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcommisionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AfpaymentEntity and AffiliateProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// Afpayment.AffiliateId - AffiliateProfile.AffiliateId
		/// </summary>
		public virtual IEntityRelation AffiliateProfileEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AffiliateProfile", false);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfpaymentFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfpaymentEntity", true);
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
