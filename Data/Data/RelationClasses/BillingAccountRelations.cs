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
	/// <summary>Implements the static Relations variant for the entity: BillingAccount. </summary>
	public partial class BillingAccountRelations
	{
		/// <summary>CTor</summary>
		public BillingAccountRelations()
		{
		}

		/// <summary>Gets all relations of the BillingAccountEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BillingAccountTestEntityUsingBillingAccountId);
			toReturn.Add(this.CustomerBillingAccountEntityUsingBillingAccountId);
			toReturn.Add(this.EncounterEntityUsingBillingAccountId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BillingAccountEntity and BillingAccountTestEntity over the 1:n relation they have, using the relation between the fields:
		/// BillingAccount.BillingAccountId - BillingAccountTest.BillingAccountId
		/// </summary>
		public virtual IEntityRelation BillingAccountTestEntityUsingBillingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BillingAccountTest" , true);
				relation.AddEntityFieldPair(BillingAccountFields.BillingAccountId, BillingAccountTestFields.BillingAccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BillingAccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BillingAccountTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BillingAccountEntity and CustomerBillingAccountEntity over the 1:n relation they have, using the relation between the fields:
		/// BillingAccount.BillingAccountId - CustomerBillingAccount.BillingAccountId
		/// </summary>
		public virtual IEntityRelation CustomerBillingAccountEntityUsingBillingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerBillingAccount" , true);
				relation.AddEntityFieldPair(BillingAccountFields.BillingAccountId, CustomerBillingAccountFields.BillingAccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BillingAccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerBillingAccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BillingAccountEntity and EncounterEntity over the 1:n relation they have, using the relation between the fields:
		/// BillingAccount.BillingAccountId - Encounter.BillingAccountId
		/// </summary>
		public virtual IEntityRelation EncounterEntityUsingBillingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Encounter" , true);
				relation.AddEntityFieldPair(BillingAccountFields.BillingAccountId, EncounterFields.BillingAccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BillingAccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EncounterEntity", false);
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
