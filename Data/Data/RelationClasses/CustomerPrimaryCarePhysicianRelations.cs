///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
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
	/// <summary>Implements the static Relations variant for the entity: CustomerPrimaryCarePhysician. </summary>
	public partial class CustomerPrimaryCarePhysicianRelations
	{
		/// <summary>CTor</summary>
		public CustomerPrimaryCarePhysicianRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerPrimaryCarePhysicianEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventCustomerPrimaryCarePhysicianEntityUsingPrimaryCarePhysicianId);

			toReturn.Add(this.AddressEntityUsingPcpaddress);
			toReturn.Add(this.AddressEntityUsingMailingAddressId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.LookupEntityUsingSource);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUpdatedByOrganizationRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingPcpAddressVerifiedBy);
			toReturn.Add(this.PhysicianMasterEntityUsingPhysicianMasterId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerPrimaryCarePhysicianEntity and EventCustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerPrimaryCarePhysician.PrimaryCarePhysicianId - EventCustomerPrimaryCarePhysician.PrimaryCarePhysicianId
		/// </summary>
		public virtual IEntityRelation EventCustomerPrimaryCarePhysicianEntityUsingPrimaryCarePhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerPrimaryCarePhysician" , true);
				relation.AddEntityFieldPair(CustomerPrimaryCarePhysicianFields.PrimaryCarePhysicianId, EventCustomerPrimaryCarePhysicianFields.PrimaryCarePhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CustomerPrimaryCarePhysicianEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerPrimaryCarePhysician.Pcpaddress - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingPcpaddress
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, CustomerPrimaryCarePhysicianFields.Pcpaddress);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerPrimaryCarePhysicianEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerPrimaryCarePhysician.MailingAddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingMailingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address_", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, CustomerPrimaryCarePhysicianFields.MailingAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerPrimaryCarePhysicianEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerPrimaryCarePhysician.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerPrimaryCarePhysicianFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerPrimaryCarePhysicianEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerPrimaryCarePhysician.Source - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerPrimaryCarePhysicianFields.Source);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerPrimaryCarePhysicianEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerPrimaryCarePhysician.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerPrimaryCarePhysicianFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerPrimaryCarePhysicianEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerPrimaryCarePhysician.UpdatedByOrganizationRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUpdatedByOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerPrimaryCarePhysicianFields.UpdatedByOrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerPrimaryCarePhysicianEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerPrimaryCarePhysician.PcpAddressVerifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingPcpAddressVerifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser__", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerPrimaryCarePhysicianFields.PcpAddressVerifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerPrimaryCarePhysicianEntity and PhysicianMasterEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerPrimaryCarePhysician.PhysicianMasterId - PhysicianMaster.PhysicianMasterId
		/// </summary>
		public virtual IEntityRelation PhysicianMasterEntityUsingPhysicianMasterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianMaster", false);
				relation.AddEntityFieldPair(PhysicianMasterFields.PhysicianMasterId, CustomerPrimaryCarePhysicianFields.PhysicianMasterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianMasterEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", true);
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
