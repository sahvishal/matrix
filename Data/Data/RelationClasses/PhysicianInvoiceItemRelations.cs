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
	/// <summary>Implements the static Relations variant for the entity: PhysicianInvoiceItem. </summary>
	public partial class PhysicianInvoiceItemRelations
	{
		/// <summary>CTor</summary>
		public PhysicianInvoiceItemRelations()
		{
		}

		/// <summary>Gets all relations of the PhysicianInvoiceItemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.PhysicianEvaluationEntityUsingPhysicianEvaluationId);
			toReturn.Add(this.PhysicianInvoiceEntityUsingPhysicianInvoiceId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PhysicianInvoiceItemEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianInvoiceItem.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, PhysicianInvoiceItemFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianInvoiceItemEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianInvoiceItem.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, PhysicianInvoiceItemFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianInvoiceItemEntity and PhysicianEvaluationEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianInvoiceItem.PhysicianEvaluationId - PhysicianEvaluation.PhysicianEvaluationId
		/// </summary>
		public virtual IEntityRelation PhysicianEvaluationEntityUsingPhysicianEvaluationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianEvaluation", false);
				relation.AddEntityFieldPair(PhysicianEvaluationFields.PhysicianEvaluationId, PhysicianInvoiceItemFields.PhysicianEvaluationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEvaluationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianInvoiceItemEntity and PhysicianInvoiceEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianInvoiceItem.PhysicianInvoiceId - PhysicianInvoice.PhysicianInvoiceId
		/// </summary>
		public virtual IEntityRelation PhysicianInvoiceEntityUsingPhysicianInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianInvoice", false);
				relation.AddEntityFieldPair(PhysicianInvoiceFields.PhysicianInvoiceId, PhysicianInvoiceItemFields.PhysicianInvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceItemEntity", true);
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
