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
	/// <summary>Implements the static Relations variant for the entity: FranchiseeWiringInstructions. </summary>
	public partial class FranchiseeWiringInstructionsRelations
	{
		/// <summary>CTor</summary>
		public FranchiseeWiringInstructionsRelations()
		{
		}

		/// <summary>Gets all relations of the FranchiseeWiringInstructionsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.PaymentFrequencyEntityUsingPaymentFrequencyId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between FranchiseeWiringInstructionsEntity and PaymentFrequencyEntity over the m:1 relation they have, using the relation between the fields:
		/// FranchiseeWiringInstructions.PaymentFrequencyId - PaymentFrequency.PaymentFrequencyId
		/// </summary>
		public virtual IEntityRelation PaymentFrequencyEntityUsingPaymentFrequencyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PaymentFrequency", false);
				relation.AddEntityFieldPair(PaymentFrequencyFields.PaymentFrequencyId, FranchiseeWiringInstructionsFields.PaymentFrequencyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentFrequencyEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FranchiseeWiringInstructionsEntity", true);
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
