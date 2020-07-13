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
	/// <summary>Implements the static Relations variant for the entity: HospitalPartner. </summary>
	public partial class HospitalPartnerRelations
	{
		/// <summary>CTor</summary>
		public HospitalPartnerRelations()
		{
		}

		/// <summary>Gets all relations of the HospitalPartnerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventHospitalPartnerEntityUsingHospitalPartnerId);
			toReturn.Add(this.HospitalPartnerHospitalFacilityEntityUsingHospitalPartnerId);
			toReturn.Add(this.HospitalPartnerPackageEntityUsingHospitalpartnerId);
			toReturn.Add(this.HospitalPartnerShippingOptionEntityUsingHospitalPartnerId);
			toReturn.Add(this.HospitalPartnerTerritoryEntityUsingHospitalPartnerId);
			toReturn.Add(this.MedicalVendorProfileEntityUsingHospitalPartnerId);
			toReturn.Add(this.HafTemplateEntityUsingHafTemplateId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerEntity and EventHospitalPartnerEntity over the 1:n relation they have, using the relation between the fields:
		/// HospitalPartner.HospitalPartnerId - EventHospitalPartner.HospitalPartnerId
		/// </summary>
		public virtual IEntityRelation EventHospitalPartnerEntityUsingHospitalPartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventHospitalPartner" , true);
				relation.AddEntityFieldPair(HospitalPartnerFields.HospitalPartnerId, EventHospitalPartnerFields.HospitalPartnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventHospitalPartnerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerEntity and HospitalPartnerHospitalFacilityEntity over the 1:n relation they have, using the relation between the fields:
		/// HospitalPartner.HospitalPartnerId - HospitalPartnerHospitalFacility.HospitalPartnerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerHospitalFacilityEntityUsingHospitalPartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerHospitalFacility" , true);
				relation.AddEntityFieldPair(HospitalPartnerFields.HospitalPartnerId, HospitalPartnerHospitalFacilityFields.HospitalPartnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerHospitalFacilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerEntity and HospitalPartnerPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// HospitalPartner.HospitalPartnerId - HospitalPartnerPackage.HospitalpartnerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerPackageEntityUsingHospitalpartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerPackage" , true);
				relation.AddEntityFieldPair(HospitalPartnerFields.HospitalPartnerId, HospitalPartnerPackageFields.HospitalpartnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerPackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerEntity and HospitalPartnerShippingOptionEntity over the 1:n relation they have, using the relation between the fields:
		/// HospitalPartner.HospitalPartnerId - HospitalPartnerShippingOption.HospitalPartnerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerShippingOptionEntityUsingHospitalPartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerShippingOption" , true);
				relation.AddEntityFieldPair(HospitalPartnerFields.HospitalPartnerId, HospitalPartnerShippingOptionFields.HospitalPartnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerShippingOptionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerEntity and HospitalPartnerTerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// HospitalPartner.HospitalPartnerId - HospitalPartnerTerritory.HospitalPartnerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerTerritoryEntityUsingHospitalPartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerTerritory" , true);
				relation.AddEntityFieldPair(HospitalPartnerFields.HospitalPartnerId, HospitalPartnerTerritoryFields.HospitalPartnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerTerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerEntity and MedicalVendorProfileEntity over the 1:1 relation they have, using the relation between the fields:
		/// HospitalPartner.HospitalPartnerId - MedicalVendorProfile.OrganizationId
		/// </summary>
		public virtual IEntityRelation MedicalVendorProfileEntityUsingHospitalPartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "MedicalVendorProfile", false);



				relation.AddEntityFieldPair(MedicalVendorProfileFields.OrganizationId, HospitalPartnerFields.HospitalPartnerId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerEntity and HafTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartner.HafTemplateId - HafTemplate.HaftemplateId
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HafTemplate", false);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, HospitalPartnerFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", true);
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
