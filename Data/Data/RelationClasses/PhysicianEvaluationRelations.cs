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
	/// <summary>Implements the static Relations variant for the entity: PhysicianEvaluation. </summary>
	public partial class PhysicianEvaluationRelations
	{
		/// <summary>CTor</summary>
		public PhysicianEvaluationRelations()
		{
		}

		/// <summary>Gets all relations of the PhysicianEvaluationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.PhysicianEarningsEntityUsingPhysicianEvaluationId);
			toReturn.Add(this.PhysicianInvoiceItemEntityUsingPhysicianEvaluationId);

			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.PhysicianProfileEntityUsingPhysicianId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PhysicianEvaluationEntity and PhysicianEarningsEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianEvaluation.PhysicianEvaluationId - PhysicianEarnings.PhysicianEvaluationId
		/// </summary>
		public virtual IEntityRelation PhysicianEarningsEntityUsingPhysicianEvaluationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianEarnings" , true);
				relation.AddEntityFieldPair(PhysicianEvaluationFields.PhysicianEvaluationId, PhysicianEarningsFields.PhysicianEvaluationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEvaluationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEarningsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianEvaluationEntity and PhysicianInvoiceItemEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianEvaluation.PhysicianEvaluationId - PhysicianInvoiceItem.PhysicianEvaluationId
		/// </summary>
		public virtual IEntityRelation PhysicianInvoiceItemEntityUsingPhysicianEvaluationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianInvoiceItem" , true);
				relation.AddEntityFieldPair(PhysicianEvaluationFields.PhysicianEvaluationId, PhysicianInvoiceItemFields.PhysicianEvaluationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEvaluationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceItemEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between PhysicianEvaluationEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianEvaluation.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, PhysicianEvaluationFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEvaluationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianEvaluationEntity and PhysicianProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianEvaluation.PhysicianId - PhysicianProfile.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianProfileEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianProfile", false);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianEvaluationFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEvaluationEntity", true);
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
