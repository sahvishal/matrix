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
	/// <summary>Implements the static Relations variant for the entity: Claim. </summary>
	public partial class ClaimRelations
	{
		/// <summary>CTor</summary>
		public ClaimRelations()
		{
		}

		/// <summary>Gets all relations of the ClaimEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EncounterEntityUsingEncounterId);
			toReturn.Add(this.InsurancePaymentEntityUsingInsurancePaymentId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ClaimEntity and EncounterEntity over the m:1 relation they have, using the relation between the fields:
		/// Claim.EncounterId - Encounter.EncounterId
		/// </summary>
		public virtual IEntityRelation EncounterEntityUsingEncounterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Encounter", false);
				relation.AddEntityFieldPair(EncounterFields.EncounterId, ClaimFields.EncounterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EncounterEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClaimEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ClaimEntity and InsurancePaymentEntity over the m:1 relation they have, using the relation between the fields:
		/// Claim.InsurancePaymentId - InsurancePayment.InsurancePaymentId
		/// </summary>
		public virtual IEntityRelation InsurancePaymentEntityUsingInsurancePaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "InsurancePayment", false);
				relation.AddEntityFieldPair(InsurancePaymentFields.InsurancePaymentId, ClaimFields.InsurancePaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InsurancePaymentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClaimEntity", true);
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
