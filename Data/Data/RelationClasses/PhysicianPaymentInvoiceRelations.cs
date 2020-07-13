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
	/// <summary>Implements the static Relations variant for the entity: PhysicianPaymentInvoice. </summary>
	public partial class PhysicianPaymentInvoiceRelations
	{
		/// <summary>CTor</summary>
		public PhysicianPaymentInvoiceRelations()
		{
		}

		/// <summary>Gets all relations of the PhysicianPaymentInvoiceEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.PhysicianInvoiceEntityUsingPhysicianInvoiceId);
			toReturn.Add(this.PhysicianPaymentEntityUsingPhysicianPaymentId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PhysicianPaymentInvoiceEntity and PhysicianInvoiceEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianPaymentInvoice.PhysicianInvoiceId - PhysicianInvoice.PhysicianInvoiceId
		/// </summary>
		public virtual IEntityRelation PhysicianInvoiceEntityUsingPhysicianInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianInvoice", false);
				relation.AddEntityFieldPair(PhysicianInvoiceFields.PhysicianInvoiceId, PhysicianPaymentInvoiceFields.PhysicianInvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPaymentInvoiceEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianPaymentInvoiceEntity and PhysicianPaymentEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianPaymentInvoice.PhysicianPaymentId - PhysicianPayment.PhysicianPaymentId
		/// </summary>
		public virtual IEntityRelation PhysicianPaymentEntityUsingPhysicianPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianPayment", false);
				relation.AddEntityFieldPair(PhysicianPaymentFields.PhysicianPaymentId, PhysicianPaymentInvoiceFields.PhysicianPaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPaymentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPaymentInvoiceEntity", true);
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
