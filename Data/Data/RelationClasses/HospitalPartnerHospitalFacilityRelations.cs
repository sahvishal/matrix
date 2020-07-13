///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:40
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
	/// <summary>Implements the static Relations variant for the entity: HospitalPartnerHospitalFacility. </summary>
	public partial class HospitalPartnerHospitalFacilityRelations
	{
		/// <summary>CTor</summary>
		public HospitalPartnerHospitalFacilityRelations()
		{
		}

		/// <summary>Gets all relations of the HospitalPartnerHospitalFacilityEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.HospitalFacilityEntityUsingHospitalFacilityId);
			toReturn.Add(this.HospitalPartnerEntityUsingHospitalPartnerId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerHospitalFacilityEntity and HospitalFacilityEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartnerHospitalFacility.HospitalFacilityId - HospitalFacility.HospitalFacilityId
		/// </summary>
		public virtual IEntityRelation HospitalFacilityEntityUsingHospitalFacilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HospitalFacility", false);
				relation.AddEntityFieldPair(HospitalFacilityFields.HospitalFacilityId, HospitalPartnerHospitalFacilityFields.HospitalFacilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalFacilityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerHospitalFacilityEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerHospitalFacilityEntity and HospitalPartnerEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartnerHospitalFacility.HospitalPartnerId - HospitalPartner.HospitalPartnerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerEntityUsingHospitalPartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HospitalPartner", false);
				relation.AddEntityFieldPair(HospitalPartnerFields.HospitalPartnerId, HospitalPartnerHospitalFacilityFields.HospitalPartnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerHospitalFacilityEntity", true);
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
