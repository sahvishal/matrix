///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:15 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: PaymentDetails. </summary>
	public partial class PaymentDetailsRelations
	{
		/// <summary>CTor</summary>
		public PaymentDetailsRelations()
		{
		}

		/// <summary>Gets all relations of the PaymentDetailsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CashPaymentDetailsEntityUsingPaymentId);
			toReturn.Add(this.ChequePaymentDetailsEntityUsingPaymentId);
			toReturn.Add(this.EcheckPaymentDetailsEntityUsingPaymentId);
			toReturn.Add(this.PaymentCouponsEntityUsingPaymentDetailsId);

			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.PaymentTypeEntityUsingPaymentTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PaymentDetailsEntity and CashPaymentDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// PaymentDetails.PaymentId - CashPaymentDetails.PaymentId
		/// </summary>
		public virtual IEntityRelation CashPaymentDetailsEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CashPaymentDetails" , true);
				relation.AddEntityFieldPair(PaymentDetailsFields.PaymentId, CashPaymentDetailsFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CashPaymentDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentDetailsEntity and ChequePaymentDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// PaymentDetails.PaymentId - ChequePaymentDetails.PaymentId
		/// </summary>
		public virtual IEntityRelation ChequePaymentDetailsEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChequePaymentDetails" , true);
				relation.AddEntityFieldPair(PaymentDetailsFields.PaymentId, ChequePaymentDetailsFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChequePaymentDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentDetailsEntity and EcheckPaymentDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// PaymentDetails.PaymentId - EcheckPaymentDetails.PaymentId
		/// </summary>
		public virtual IEntityRelation EcheckPaymentDetailsEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EcheckPaymentDetails" , true);
				relation.AddEntityFieldPair(PaymentDetailsFields.PaymentId, EcheckPaymentDetailsFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EcheckPaymentDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentDetailsEntity and PaymentCouponsEntity over the 1:n relation they have, using the relation between the fields:
		/// PaymentDetails.PaymentId - PaymentCoupons.PaymentDetailsId
		/// </summary>
		public virtual IEntityRelation PaymentCouponsEntityUsingPaymentDetailsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PaymentCoupons" , true);
				relation.AddEntityFieldPair(PaymentDetailsFields.PaymentId, PaymentCouponsFields.PaymentDetailsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentCouponsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between PaymentDetailsEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// PaymentDetails.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, PaymentDetailsFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PaymentDetailsEntity and PaymentTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// PaymentDetails.PaymentTypeId - PaymentType.PaymentTypeId
		/// </summary>
		public virtual IEntityRelation PaymentTypeEntityUsingPaymentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PaymentType", false);
				relation.AddEntityFieldPair(PaymentTypeFields.PaymentTypeId, PaymentDetailsFields.PaymentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentDetailsEntity", true);
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
