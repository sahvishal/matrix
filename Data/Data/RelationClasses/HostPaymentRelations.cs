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
	/// <summary>Implements the static Relations variant for the entity: HostPayment. </summary>
	public partial class HostPaymentRelations
	{
		/// <summary>CTor</summary>
		public HostPaymentRelations()
		{
		}

		/// <summary>Gets all relations of the HostPaymentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.HostPaymentTransactionEntityUsingHostPaymentId);

			toReturn.Add(this.AddressEntityUsingMailingAddressId);
			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.LookupEntityUsingStatus);
			toReturn.Add(this.LookupEntityUsingDepositType);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatorOrganizationRoleUserId);
			toReturn.Add(this.ProspectsEntityUsingHostId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between HostPaymentEntity and HostPaymentTransactionEntity over the 1:n relation they have, using the relation between the fields:
		/// HostPayment.HostPaymentId - HostPaymentTransaction.HostPaymentId
		/// </summary>
		public virtual IEntityRelation HostPaymentTransactionEntityUsingHostPaymentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPaymentTransaction" , true);
				relation.AddEntityFieldPair(HostPaymentFields.HostPaymentId, HostPaymentTransactionFields.HostPaymentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentTransactionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between HostPaymentEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPayment.MailingAddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingMailingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, HostPaymentFields.MailingAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostPaymentEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPayment.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, HostPaymentFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostPaymentEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPayment.Status - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup___", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostPaymentFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostPaymentEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPayment.DepositType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingDepositType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup__", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostPaymentFields.DepositType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostPaymentEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPayment.CreatorOrganizationRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatorOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HostPaymentFields.CreatorOrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostPaymentEntity and ProspectsEntity over the m:1 relation they have, using the relation between the fields:
		/// HostPayment.HostId - Prospects.ProspectId
		/// </summary>
		public virtual IEntityRelation ProspectsEntityUsingHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Prospects", false);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, HostPaymentFields.HostId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", true);
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
