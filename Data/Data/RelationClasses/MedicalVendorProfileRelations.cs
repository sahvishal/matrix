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
	/// <summary>Implements the static Relations variant for the entity: MedicalVendorProfile. </summary>
	public partial class MedicalVendorProfileRelations
	{
		/// <summary>CTor</summary>
		public MedicalVendorProfileRelations()
		{
		}

		/// <summary>Gets all relations of the MedicalVendorProfileEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.HospitalPartnerEntityUsingHospitalPartnerId);
			toReturn.Add(this.OrganizationEntityUsingOrganizationId);
			toReturn.Add(this.ContractEntityUsingContractId);
			toReturn.Add(this.FileEntityUsingDoctorLetterFileId);
			toReturn.Add(this.FileEntityUsingResultLetterCoBrandingFileId);
			toReturn.Add(this.MedicalVendorTypeEntityUsingTypeId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between MedicalVendorProfileEntity and HospitalPartnerEntity over the 1:1 relation they have, using the relation between the fields:
		/// MedicalVendorProfile.OrganizationId - HospitalPartner.HospitalPartnerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerEntityUsingHospitalPartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "HospitalPartner", true);

				relation.AddEntityFieldPair(MedicalVendorProfileFields.OrganizationId, HospitalPartnerFields.HospitalPartnerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicalVendorProfileEntity and OrganizationEntity over the 1:1 relation they have, using the relation between the fields:
		/// MedicalVendorProfile.OrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "Organization", false);



				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, MedicalVendorProfileFields.OrganizationId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicalVendorProfileEntity and ContractEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicalVendorProfile.ContractId - Contract.ContractId
		/// </summary>
		public virtual IEntityRelation ContractEntityUsingContractId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Contract", false);
				relation.AddEntityFieldPair(ContractFields.ContractId, MedicalVendorProfileFields.ContractId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContractEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicalVendorProfileEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicalVendorProfile.DoctorLetterFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingDoctorLetterFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, MedicalVendorProfileFields.DoctorLetterFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicalVendorProfileEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicalVendorProfile.ResultLetterCoBrandingFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingResultLetterCoBrandingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, MedicalVendorProfileFields.ResultLetterCoBrandingFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicalVendorProfileEntity and MedicalVendorTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicalVendorProfile.TypeId - MedicalVendorType.MedicalVendorTypeId
		/// </summary>
		public virtual IEntityRelation MedicalVendorTypeEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MedicalVendorType", false);
				relation.AddEntityFieldPair(MedicalVendorTypeFields.MedicalVendorTypeId, MedicalVendorProfileFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", true);
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
