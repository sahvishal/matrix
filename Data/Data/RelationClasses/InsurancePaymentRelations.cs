///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:40
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
	/// <summary>Implements the static Relations variant for the entity: InsurancePayment. </summary>
	public partial class InsurancePaymentRelations
	{
		/// <summary>CTor</summary>
		public InsurancePaymentRelations()
		{
		}

		/// <summary>Gets all relations of the InsurancePaymentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ClaimEntityUsingInsurancePaymentId);

			toReturn.Add(this.PaymentEntityUsingPaymentId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between InsurancePaymentEntity and ClaimEntity over the 1:n relation they have, using the relation between the fields:
		/// InsurancePayment.InsurancePaymentId - Claim.InsurancePaymentId
		/// </summary>
		public virtual IEntityRelation ClaimEntityUsingInsurancePaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Claim" , true);
				relation.AddEntityFieldPair(InsurancePaymentFields.InsurancePaymentId, ClaimFields.InsurancePaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InsurancePaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClaimEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between InsurancePaymentEntity and PaymentEntity over the m:1 relation they have, using the relation between the fields:
		/// InsurancePayment.PaymentId - Payment.PaymentId
		/// </summary>
		public virtual IEntityRelation PaymentEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Payment", false);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, InsurancePaymentFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InsurancePaymentEntity", true);
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
