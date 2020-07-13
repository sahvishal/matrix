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
	/// <summary>Implements the static Relations variant for the entity: Encounter. </summary>
	public partial class EncounterRelations
	{
		/// <summary>CTor</summary>
		public EncounterRelations()
		{
		}

		/// <summary>Gets all relations of the EncounterEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ClaimEntityUsingEncounterId);
			toReturn.Add(this.EventCustomerEncounterEntityUsingEncounterId);

			toReturn.Add(this.BillingAccountEntityUsingBillingAccountId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EncounterEntity and ClaimEntity over the 1:n relation they have, using the relation between the fields:
		/// Encounter.EncounterId - Claim.EncounterId
		/// </summary>
		public virtual IEntityRelation ClaimEntityUsingEncounterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Claim" , true);
				relation.AddEntityFieldPair(EncounterFields.EncounterId, ClaimFields.EncounterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EncounterEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClaimEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EncounterEntity and EventCustomerEncounterEntity over the 1:n relation they have, using the relation between the fields:
		/// Encounter.EncounterId - EventCustomerEncounter.EncounterId
		/// </summary>
		public virtual IEntityRelation EventCustomerEncounterEntityUsingEncounterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerEncounter" , true);
				relation.AddEntityFieldPair(EncounterFields.EncounterId, EventCustomerEncounterFields.EncounterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EncounterEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerEncounterEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between EncounterEntity and BillingAccountEntity over the m:1 relation they have, using the relation between the fields:
		/// Encounter.BillingAccountId - BillingAccount.BillingAccountId
		/// </summary>
		public virtual IEntityRelation BillingAccountEntityUsingBillingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BillingAccount", false);
				relation.AddEntityFieldPair(BillingAccountFields.BillingAccountId, EncounterFields.BillingAccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BillingAccountEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EncounterEntity", true);
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
