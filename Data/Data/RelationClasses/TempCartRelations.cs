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
	/// <summary>Implements the static Relations variant for the entity: TempCart. </summary>
	public partial class TempCartRelations
	{
		/// <summary>CTor</summary>
		public TempCartRelations()
		{
		}

		/// <summary>Gets all relations of the TempCartEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.PreQualificationResultEntityUsingTempCartId);

			toReturn.Add(this.ChargeCardEntityUsingChargeCardId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.EligibilityEntityUsingEligibilityId);
			toReturn.Add(this.ProspectCustomerEntityUsingProspectCustomerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TempCartEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// TempCart.Id - PreQualificationResult.TempCartId
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingTempCartId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult" , true);
				relation.AddEntityFieldPair(TempCartFields.Id, PreQualificationResultFields.TempCartId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TempCartEntity and ChargeCardEntity over the m:1 relation they have, using the relation between the fields:
		/// TempCart.ChargeCardId - ChargeCard.ChargeCardId
		/// </summary>
		public virtual IEntityRelation ChargeCardEntityUsingChargeCardId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ChargeCard", false);
				relation.AddEntityFieldPair(ChargeCardFields.ChargeCardId, TempCartFields.ChargeCardId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChargeCardEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TempCartEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// TempCart.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, TempCartFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TempCartEntity and EligibilityEntity over the m:1 relation they have, using the relation between the fields:
		/// TempCart.EligibilityId - Eligibility.EligibilityId
		/// </summary>
		public virtual IEntityRelation EligibilityEntityUsingEligibilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Eligibility", false);
				relation.AddEntityFieldPair(EligibilityFields.EligibilityId, TempCartFields.EligibilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TempCartEntity and ProspectCustomerEntity over the m:1 relation they have, using the relation between the fields:
		/// TempCart.ProspectCustomerId - ProspectCustomer.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ProspectCustomer", false);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, TempCartFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", true);
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
