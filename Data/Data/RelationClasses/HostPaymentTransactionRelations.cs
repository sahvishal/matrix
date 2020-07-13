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
	/// <summary>Implements the static Relations variant for the entity: HostPaymentTransaction. </summary>
	public partial class HostPaymentTransactionRelations
	{
		/// <summary>CTor</summary>
		public HostPaymentTransactionRelations()
		{
		}

		/// <summary>Gets all relations of the HostPaymentTransactionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.HostPaymentEntityUsingHostPaymentId);
			toReturn.Add(this.LookupEntityUsingTransactionType);
			toReturn.Add(this.LookupEntityUsingPaymentMethod);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HostPaymentTransactionEntity and HostPaymentEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPaymentTransaction.HostPaymentId - HostPayment.HostPaymentId
		/// </summary>
		public virtual IEntityRelation HostPaymentEntityUsingHostPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HostPayment", false);
				relation.AddEntityFieldPair(HostPaymentFields.HostPaymentId, HostPaymentTransactionFields.HostPaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentTransactionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostPaymentTransactionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPaymentTransaction.TransactionType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTransactionType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostPaymentTransactionFields.TransactionType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentTransactionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostPaymentTransactionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPaymentTransaction.PaymentMethod - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingPaymentMethod
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostPaymentTransactionFields.PaymentMethod);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentTransactionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostPaymentTransactionEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPaymentTransaction.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HostPaymentTransactionFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentTransactionEntity", true);
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
