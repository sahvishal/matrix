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
	/// <summary>Implements the static Relations variant for the entity: MVPaymentCheckDetails. </summary>
	public partial class MVPaymentCheckDetailsRelations
	{
		/// <summary>CTor</summary>
		public MVPaymentCheckDetailsRelations()
		{
		}

		/// <summary>Gets all relations of the MVPaymentCheckDetailsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CheckEntityUsingCheckId);
			toReturn.Add(this.PhysicianPaymentEntityUsingMvpaymentId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between MVPaymentCheckDetailsEntity and CheckEntity over the m:1 relation they have, using the relation between the fields:
		/// MVPaymentCheckDetails.CheckId - Check.CheckId
		/// </summary>
		public virtual IEntityRelation CheckEntityUsingCheckId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Check", false);
				relation.AddEntityFieldPair(CheckFields.CheckId, MVPaymentCheckDetailsFields.CheckId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MVPaymentCheckDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MVPaymentCheckDetailsEntity and PhysicianPaymentEntity over the m:1 relation they have, using the relation between the fields:
		/// MVPaymentCheckDetails.MvpaymentId - PhysicianPayment.PhysicianPaymentId
		/// </summary>
		public virtual IEntityRelation PhysicianPaymentEntityUsingMvpaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianPayment", false);
				relation.AddEntityFieldPair(PhysicianPaymentFields.PhysicianPaymentId, MVPaymentCheckDetailsFields.MvpaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPaymentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MVPaymentCheckDetailsEntity", true);
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
