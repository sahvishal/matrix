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
	/// <summary>Implements the static Relations variant for the entity: HospitalFacility. </summary>
	public partial class HospitalFacilityRelations
	{
		/// <summary>CTor</summary>
		public HospitalFacilityRelations()
		{
		}

		/// <summary>Gets all relations of the HospitalFacilityEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventCustomersEntityUsingHospitalFacilityId);
			toReturn.Add(this.EventHospitalFacilityEntityUsingHospitalFacilityId);
			toReturn.Add(this.HospitalPartnerHospitalFacilityEntityUsingHospitalFacilityId);
			toReturn.Add(this.OrganizationEntityUsingHospitalFacilityId);
			toReturn.Add(this.ContractEntityUsingContractId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between HospitalFacilityEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// HospitalFacility.HospitalFacilityId - EventCustomers.HospitalFacilityId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingHospitalFacilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers" , true);
				relation.AddEntityFieldPair(HospitalFacilityFields.HospitalFacilityId, EventCustomersFields.HospitalFacilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalFacilityEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalFacilityEntity and EventHospitalFacilityEntity over the 1:n relation they have, using the relation between the fields:
		/// HospitalFacility.HospitalFacilityId - EventHospitalFacility.HospitalFacilityId
		/// </summary>
		public virtual IEntityRelation EventHospitalFacilityEntityUsingHospitalFacilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventHospitalFacility" , true);
				relation.AddEntityFieldPair(HospitalFacilityFields.HospitalFacilityId, EventHospitalFacilityFields.HospitalFacilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalFacilityEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventHospitalFacilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalFacilityEntity and HospitalPartnerHospitalFacilityEntity over the 1:n relation they have, using the relation between the fields:
		/// HospitalFacility.HospitalFacilityId - HospitalPartnerHospitalFacility.HospitalFacilityId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerHospitalFacilityEntityUsingHospitalFacilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerHospitalFacility" , true);
				relation.AddEntityFieldPair(HospitalFacilityFields.HospitalFacilityId, HospitalPartnerHospitalFacilityFields.HospitalFacilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalFacilityEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerHospitalFacilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalFacilityEntity and OrganizationEntity over the 1:1 relation they have, using the relation between the fields:
		/// HospitalFacility.HospitalFacilityId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingHospitalFacilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "Organization", false);



				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, HospitalFacilityFields.HospitalFacilityId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalFacilityEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalFacilityEntity and ContractEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalFacility.ContractId - Contract.ContractId
		/// </summary>
		public virtual IEntityRelation ContractEntityUsingContractId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Contract", false);
				relation.AddEntityFieldPair(ContractFields.ContractId, HospitalFacilityFields.ContractId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContractEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalFacilityEntity", true);
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
