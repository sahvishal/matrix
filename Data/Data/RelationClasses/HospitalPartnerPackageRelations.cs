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
	/// <summary>Implements the static Relations variant for the entity: HospitalPartnerPackage. </summary>
	public partial class HospitalPartnerPackageRelations
	{
		/// <summary>CTor</summary>
		public HospitalPartnerPackageRelations()
		{
		}

		/// <summary>Gets all relations of the HospitalPartnerPackageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.HospitalPartnerEntityUsingHospitalpartnerId);
			toReturn.Add(this.PackageEntityUsingPackageId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerPackageEntity and HospitalPartnerEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartnerPackage.HospitalpartnerId - HospitalPartner.HospitalPartnerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerEntityUsingHospitalpartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HospitalPartner", false);
				relation.AddEntityFieldPair(HospitalPartnerFields.HospitalPartnerId, HospitalPartnerPackageFields.HospitalpartnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerPackageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerPackageEntity and PackageEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartnerPackage.PackageId - Package.PackageId
		/// </summary>
		public virtual IEntityRelation PackageEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Package", false);
				relation.AddEntityFieldPair(PackageFields.PackageId, HospitalPartnerPackageFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerPackageEntity", true);
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
