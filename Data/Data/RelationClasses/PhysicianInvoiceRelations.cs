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
	/// <summary>Implements the static Relations variant for the entity: PhysicianInvoice. </summary>
	public partial class PhysicianInvoiceRelations
	{
		/// <summary>CTor</summary>
		public PhysicianInvoiceRelations()
		{
		}

		/// <summary>Gets all relations of the PhysicianInvoiceEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.PhysicianInvoiceItemEntityUsingPhysicianInvoiceId);
			toReturn.Add(this.PhysicianPaymentInvoiceEntityUsingPhysicianInvoiceId);

			toReturn.Add(this.PhysicianProfileEntityUsingPhysicianId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PhysicianInvoiceEntity and PhysicianInvoiceItemEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianInvoice.PhysicianInvoiceId - PhysicianInvoiceItem.PhysicianInvoiceId
		/// </summary>
		public virtual IEntityRelation PhysicianInvoiceItemEntityUsingPhysicianInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianInvoiceItem" , true);
				relation.AddEntityFieldPair(PhysicianInvoiceFields.PhysicianInvoiceId, PhysicianInvoiceItemFields.PhysicianInvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PhysicianInvoiceEntity and PhysicianPaymentInvoiceEntity over the 1:n relation they have, using the relation between the fields:
		/// PhysicianInvoice.PhysicianInvoiceId - PhysicianPaymentInvoice.PhysicianInvoiceId
		/// </summary>
		public virtual IEntityRelation PhysicianPaymentInvoiceEntityUsingPhysicianInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianPaymentInvoice" , true);
				relation.AddEntityFieldPair(PhysicianInvoiceFields.PhysicianInvoiceId, PhysicianPaymentInvoiceFields.PhysicianInvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPaymentInvoiceEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between PhysicianInvoiceEntity and PhysicianProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianInvoice.PhysicianId - PhysicianProfile.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianProfileEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianProfile", false);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianInvoiceFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceEntity", true);
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
