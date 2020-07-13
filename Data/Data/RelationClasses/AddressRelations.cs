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
	/// <summary>Implements the static Relations variant for the entity: Address. </summary>
	public partial class AddressRelations
	{
		/// <summary>CTor</summary>
		public AddressRelations()
		{
		}

		/// <summary>Gets all relations of the AddressEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerPrimaryCarePhysicianEntityUsingPcpaddress);
			toReturn.Add(this.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId);
			toReturn.Add(this.CustomerProfileEntityUsingBillingAddressId);
			toReturn.Add(this.HostPaymentEntityUsingMailingAddressId);
			toReturn.Add(this.OrganizationEntityUsingBusinessAddressId);
			toReturn.Add(this.ProspectsEntityUsingAddressId);
			toReturn.Add(this.ShippingDetailEntityUsingShippingAddressId);
			toReturn.Add(this.UserEntityUsingHomeAddressId);

			toReturn.Add(this.CityEntityUsingCityId);
			toReturn.Add(this.CountryEntityUsingCountryId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingVerificationOrgRoleUserId);
			toReturn.Add(this.StateEntityUsingStateId);
			toReturn.Add(this.ZipEntityUsingZipId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AddressEntity and CustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// Address.AddressId - CustomerPrimaryCarePhysician.Pcpaddress
		/// </summary>
		public virtual IEntityRelation CustomerPrimaryCarePhysicianEntityUsingPcpaddress
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPrimaryCarePhysician" , true);
				relation.AddEntityFieldPair(AddressFields.AddressId, CustomerPrimaryCarePhysicianFields.Pcpaddress);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AddressEntity and CustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// Address.AddressId - CustomerPrimaryCarePhysician.MailingAddressId
		/// </summary>
		public virtual IEntityRelation CustomerPrimaryCarePhysicianEntityUsingMailingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPrimaryCarePhysician_" , true);
				relation.AddEntityFieldPair(AddressFields.AddressId, CustomerPrimaryCarePhysicianFields.MailingAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AddressEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Address.AddressId - CustomerProfile.BillingAddressId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingBillingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile" , true);
				relation.AddEntityFieldPair(AddressFields.AddressId, CustomerProfileFields.BillingAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AddressEntity and HostPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Address.AddressId - HostPayment.MailingAddressId
		/// </summary>
		public virtual IEntityRelation HostPaymentEntityUsingMailingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPayment" , true);
				relation.AddEntityFieldPair(AddressFields.AddressId, HostPaymentFields.MailingAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AddressEntity and OrganizationEntity over the 1:n relation they have, using the relation between the fields:
		/// Address.AddressId - Organization.BusinessAddressId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingBusinessAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Organization" , true);
				relation.AddEntityFieldPair(AddressFields.AddressId, OrganizationFields.BusinessAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AddressEntity and ProspectsEntity over the 1:n relation they have, using the relation between the fields:
		/// Address.AddressId - Prospects.AddressId
		/// </summary>
		public virtual IEntityRelation ProspectsEntityUsingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Prospects" , true);
				relation.AddEntityFieldPair(AddressFields.AddressId, ProspectsFields.AddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AddressEntity and ShippingDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// Address.AddressId - ShippingDetail.ShippingAddressId
		/// </summary>
		public virtual IEntityRelation ShippingDetailEntityUsingShippingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingDetail" , true);
				relation.AddEntityFieldPair(AddressFields.AddressId, ShippingDetailFields.ShippingAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AddressEntity and UserEntity over the 1:n relation they have, using the relation between the fields:
		/// Address.AddressId - User.HomeAddressId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingHomeAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "User" , true);
				relation.AddEntityFieldPair(AddressFields.AddressId, UserFields.HomeAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AddressEntity and CityEntity over the m:1 relation they have, using the relation between the fields:
		/// Address.CityId - City.CityId
		/// </summary>
		public virtual IEntityRelation CityEntityUsingCityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "City", false);
				relation.AddEntityFieldPair(CityFields.CityId, AddressFields.CityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AddressEntity and CountryEntity over the m:1 relation they have, using the relation between the fields:
		/// Address.CountryId - Country.CountryId
		/// </summary>
		public virtual IEntityRelation CountryEntityUsingCountryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Country", false);
				relation.AddEntityFieldPair(CountryFields.CountryId, AddressFields.CountryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AddressEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Address.VerificationOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingVerificationOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AddressFields.VerificationOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AddressEntity and StateEntity over the m:1 relation they have, using the relation between the fields:
		/// Address.StateId - State.StateId
		/// </summary>
		public virtual IEntityRelation StateEntityUsingStateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "State", false);
				relation.AddEntityFieldPair(StateFields.StateId, AddressFields.StateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AddressEntity and ZipEntity over the m:1 relation they have, using the relation between the fields:
		/// Address.ZipId - Zip.ZipId
		/// </summary>
		public virtual IEntityRelation ZipEntityUsingZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Zip", false);
				relation.AddEntityFieldPair(ZipFields.ZipId, AddressFields.ZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
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
