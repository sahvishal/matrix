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
	/// <summary>Implements the static Relations variant for the entity: HospitalPartnerTerritory. </summary>
	public partial class HospitalPartnerTerritoryRelations
	{
		/// <summary>CTor</summary>
		public HospitalPartnerTerritoryRelations()
		{
		}

		/// <summary>Gets all relations of the HospitalPartnerTerritoryEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.HospitalPartnerEntityUsingHospitalPartnerId);
			toReturn.Add(this.TerritoryEntityUsingTerritoryId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerTerritoryEntity and HospitalPartnerEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartnerTerritory.HospitalPartnerId - HospitalPartner.HospitalPartnerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerEntityUsingHospitalPartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HospitalPartner", false);
				relation.AddEntityFieldPair(HospitalPartnerFields.HospitalPartnerId, HospitalPartnerTerritoryFields.HospitalPartnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerTerritoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerTerritoryEntity and TerritoryEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartnerTerritory.TerritoryId - Territory.TerritoryId
		/// </summary>
		public virtual IEntityRelation TerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Territory", false);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, HospitalPartnerTerritoryFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerTerritoryEntity", true);
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
