///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
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
	/// <summary>Implements the static Relations variant for the entity: ChargeCard. </summary>
	public partial class ChargeCardRelations
	{
		/// <summary>CTor</summary>
		public ChargeCardRelations()
		{
		}

		/// <summary>Gets all relations of the ChargeCardEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ChargeCardPaymentEntityUsingChargeCardId);
			toReturn.Add(this.EventCustomerEligibilityEntityUsingChargeCardId);
			toReturn.Add(this.TempCartEntityUsingChargeCardId);

			toReturn.Add(this.CreditCardTypeEntityUsingTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ChargeCardEntity and ChargeCardPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// ChargeCard.ChargeCardId - ChargeCardPayment.ChargeCardId
		/// </summary>
		public virtual IEntityRelation ChargeCardPaymentEntityUsingChargeCardId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChargeCardPayment" , true);
				relation.AddEntityFieldPair(ChargeCardFields.ChargeCardId, ChargeCardPaymentFields.ChargeCardId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ChargeCardEntity and EventCustomerEligibilityEntity over the 1:n relation they have, using the relation between the fields:
		/// ChargeCard.ChargeCardId - EventCustomerEligibility.ChargeCardId
		/// </summary>
		public virtual IEntityRelation EventCustomerEligibilityEntityUsingChargeCardId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerEligibility" , true);
				relation.AddEntityFieldPair(ChargeCardFields.ChargeCardId, EventCustomerEligibilityFields.ChargeCardId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerEligibilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ChargeCardEntity and TempCartEntity over the 1:n relation they have, using the relation between the fields:
		/// ChargeCard.ChargeCardId - TempCart.ChargeCardId
		/// </summary>
		public virtual IEntityRelation TempCartEntityUsingChargeCardId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TempCart" , true);
				relation.AddEntityFieldPair(ChargeCardFields.ChargeCardId, TempCartFields.ChargeCardId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ChargeCardEntity and CreditCardTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ChargeCard.TypeId - CreditCardType.CreditCardTypeId
		/// </summary>
		public virtual IEntityRelation CreditCardTypeEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CreditCardType", false);
				relation.AddEntityFieldPair(CreditCardTypeFields.CreditCardTypeId, ChargeCardFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CreditCardTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardEntity", true);
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
