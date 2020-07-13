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
	/// <summary>Implements the static Relations variant for the entity: ChargeCardPayment. </summary>
	public partial class ChargeCardPaymentRelations
	{
		/// <summary>CTor</summary>
		public ChargeCardPaymentRelations()
		{
		}

		/// <summary>Gets all relations of the ChargeCardPaymentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ChargeCardEntityUsingChargeCardId);
			toReturn.Add(this.PaymentEntityUsingPaymentId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ChargeCardPaymentEntity and ChargeCardEntity over the m:1 relation they have, using the relation between the fields:
		/// ChargeCardPayment.ChargeCardId - ChargeCard.ChargeCardId
		/// </summary>
		public virtual IEntityRelation ChargeCardEntityUsingChargeCardId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ChargeCard", false);
				relation.AddEntityFieldPair(ChargeCardFields.ChargeCardId, ChargeCardPaymentFields.ChargeCardId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardPaymentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ChargeCardPaymentEntity and PaymentEntity over the m:1 relation they have, using the relation between the fields:
		/// ChargeCardPayment.PaymentId - Payment.PaymentId
		/// </summary>
		public virtual IEntityRelation PaymentEntityUsingPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Payment", false);
				relation.AddEntityFieldPair(PaymentFields.PaymentId, ChargeCardPaymentFields.PaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardPaymentEntity", true);
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
