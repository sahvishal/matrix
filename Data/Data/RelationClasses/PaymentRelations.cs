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
	/// <summary>Implements the static Relations variant for the entity: Payment. </summary>
	public partial class PaymentRelations
	{
		/// <summary>CTor</summary>
		public PaymentRelations()
		{
		}

		/// <summary>Gets all relations of the PaymentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CashPaymentEntityUsingPaymentId);
			toReturn.Add(this.ChargeCardPaymentEntityUsingPaymentId);
			toReturn.Add(this.CheckPaymentEntityUsingPaymentId);
			toReturn.Add(this.EcheckPaymentEntityUsingPaymentId);
			toReturn.Add(this.GiftCertificatePaymentEntityUsingPaymentId);
			toReturn.Add(this.InsurancePaymentEntityUsingPaymentId);
			toReturn.Add(this.PaymentOrderEntityUsingPaymentId);
			toReturn.Add(this.TestOrderItemEntityUsingTestId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PaymentEntity and CashPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Payment.PaymentId - CashPayment.PaymentId
		/// </summary>
		public virtual IEntityRelation CashPaymentEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CashPayment" , true);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, CashPaymentFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CashPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentEntity and ChargeCardPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Payment.PaymentId - ChargeCardPayment.PaymentId
		/// </summary>
		public virtual IEntityRelation ChargeCardPaymentEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChargeCardPayment" , true);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, ChargeCardPaymentFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentEntity and CheckPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Payment.PaymentId - CheckPayment.PaymentId
		/// </summary>
		public virtual IEntityRelation CheckPaymentEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckPayment" , true);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, CheckPaymentFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentEntity and EcheckPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Payment.PaymentId - EcheckPayment.PaymentId
		/// </summary>
		public virtual IEntityRelation EcheckPaymentEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EcheckPayment" , true);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, EcheckPaymentFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EcheckPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentEntity and GiftCertificatePaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Payment.PaymentId - GiftCertificatePayment.PaymentId
		/// </summary>
		public virtual IEntityRelation GiftCertificatePaymentEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GiftCertificatePayment" , true);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, GiftCertificatePaymentFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificatePaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentEntity and InsurancePaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Payment.PaymentId - InsurancePayment.PaymentId
		/// </summary>
		public virtual IEntityRelation InsurancePaymentEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InsurancePayment" , true);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, InsurancePaymentFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InsurancePaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentEntity and PaymentOrderEntity over the 1:n relation they have, using the relation between the fields:
		/// Payment.PaymentId - PaymentOrder.PaymentId
		/// </summary>
		public virtual IEntityRelation PaymentOrderEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PaymentOrder" , true);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, PaymentOrderFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentOrderEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PaymentEntity and TestOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// Payment.PaymentId - TestOrderItem.TestId
		/// </summary>
		public virtual IEntityRelation TestOrderItemEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestOrderItem" , true);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, TestOrderItemFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestOrderItemEntity", false);
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
