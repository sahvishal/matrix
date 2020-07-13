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
	/// <summary>Implements the static Relations variant for the entity: Package. </summary>
	public partial class PackageRelations
	{
		/// <summary>CTor</summary>
		public PackageRelations()
		{
		}

		/// <summary>Gets all relations of the PackageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountPackageEntityUsingPackageId);
			toReturn.Add(this.EventCustomerPreApprovedPackageTestEntityUsingPackageId);
			toReturn.Add(this.EventPackageDetailsEntityUsingPackageId);
			toReturn.Add(this.GiftCertificateEntityUsingApplicablePackageId);
			toReturn.Add(this.HealthPlanRevenueItemEntityUsingPackageId);
			toReturn.Add(this.HospitalPartnerPackageEntityUsingPackageId);
			toReturn.Add(this.PackageSourceCodeDiscountEntityUsingPackageId);
			toReturn.Add(this.PackageTestEntityUsingPackageId);
			toReturn.Add(this.PodPackageEntityUsingPackageId);
			toReturn.Add(this.PreApprovedPackageEntityUsingPackageId);
			toReturn.Add(this.TerritoryPackageEntityUsingPackageId);

			toReturn.Add(this.FileEntityUsingForOrderDisplayFileId);
			toReturn.Add(this.HafTemplateEntityUsingHafTemplateId);
			toReturn.Add(this.LookupEntityUsingGender);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and AccountPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - AccountPackage.PackageId
		/// </summary>
		public virtual IEntityRelation AccountPackageEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountPackage" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, AccountPackageFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountPackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and EventCustomerPreApprovedPackageTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - EventCustomerPreApprovedPackageTest.PackageId
		/// </summary>
		public virtual IEntityRelation EventCustomerPreApprovedPackageTestEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerPreApprovedPackageTest" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, EventCustomerPreApprovedPackageTestFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerPreApprovedPackageTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and EventPackageDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - EventPackageDetails.PackageId
		/// </summary>
		public virtual IEntityRelation EventPackageDetailsEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPackageDetails" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, EventPackageDetailsFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and GiftCertificateEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - GiftCertificate.ApplicablePackageId
		/// </summary>
		public virtual IEntityRelation GiftCertificateEntityUsingApplicablePackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GiftCertificate" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, GiftCertificateFields.ApplicablePackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and HealthPlanRevenueItemEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - HealthPlanRevenueItem.PackageId
		/// </summary>
		public virtual IEntityRelation HealthPlanRevenueItemEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanRevenueItem" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, HealthPlanRevenueItemFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and HospitalPartnerPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - HospitalPartnerPackage.PackageId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerPackageEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerPackage" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, HospitalPartnerPackageFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerPackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and PackageSourceCodeDiscountEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - PackageSourceCodeDiscount.PackageId
		/// </summary>
		public virtual IEntityRelation PackageSourceCodeDiscountEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PackageSourceCodeDiscount" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, PackageSourceCodeDiscountFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageSourceCodeDiscountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and PackageTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - PackageTest.PackageId
		/// </summary>
		public virtual IEntityRelation PackageTestEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PackageTest" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, PackageTestFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and PodPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - PodPackage.PackageId
		/// </summary>
		public virtual IEntityRelation PodPackageEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodPackage" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, PodPackageFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodPackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and PreApprovedPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - PreApprovedPackage.PackageId
		/// </summary>
		public virtual IEntityRelation PreApprovedPackageEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreApprovedPackage" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, PreApprovedPackageFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreApprovedPackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PackageEntity and TerritoryPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// Package.PackageId - TerritoryPackage.PackageId
		/// </summary>
		public virtual IEntityRelation TerritoryPackageEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TerritoryPackage" , true);
				relation.AddEntityFieldPair(PackageFields.PackageId, TerritoryPackageFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryPackageEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between PackageEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Package.ForOrderDisplayFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingForOrderDisplayFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, PackageFields.ForOrderDisplayFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PackageEntity and HafTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Package.HafTemplateId - HafTemplate.HaftemplateId
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HafTemplate", false);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, PackageFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PackageEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Package.Gender - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PackageFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", true);
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
