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
	/// <summary>Implements the static Relations variant for the entity: PhysicianPayment. </summary>
	public partial class PhysicianPaymentRelations
	{
		/// <summary>CTor</summary>
		public PhysicianPaymentRelations()
		{
		}

		/// <summary>Gets all relations of the PhysicianPaymentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.MVPaymentCheckDetailsEntityUsingMvpaymentId);
			toReturn.Add(this.PhysicianPaymentInvoiceEntityUsingPhysicianPaymentId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PhysicianPaymentEntity and MVPaymentCheckDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianPayment.PhysicianPaymentId - MVPaymentCheckDetails.MvpaymentId
		/// </summary>
		public virtual IEntityRelation MVPaymentCheckDetailsEntityUsingMvpaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MvpaymentCheckDetails" , true);
				relation.AddEntityFieldPair(PhysicianPaymentFields.PhysicianPaymentId, MVPaymentCheckDetailsFields.MvpaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MVPaymentCheckDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianPaymentEntity and PhysicianPaymentInvoiceEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianPayment.PhysicianPaymentId - PhysicianPaymentInvoice.PhysicianPaymentId
		/// </summary>
		public virtual IEntityRelation PhysicianPaymentInvoiceEntityUsingPhysicianPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianPaymentInvoice" , true);
				relation.AddEntityFieldPair(PhysicianPaymentFields.PhysicianPaymentId, PhysicianPaymentInvoiceFields.PhysicianPaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPaymentInvoiceEntity", false);
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
