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
	/// <summary>Implements the static Relations variant for the entity: HostFacilityRanking. </summary>
	public partial class HostFacilityRankingRelations
	{
		/// <summary>CTor</summary>
		public HostFacilityRankingRelations()
		{
		}

		/// <summary>Gets all relations of the HostFacilityRankingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.LookupEntityUsingRanking);
			toReturn.Add(this.LookupEntityUsingInternetAccess);
			toReturn.Add(this.OrganizationRoleUserEntityUsingRankedByOrganizationRoleUserId);
			toReturn.Add(this.ProspectsEntityUsingHostId);
			toReturn.Add(this.RoleEntityUsingRankedByRole);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HostFacilityRankingEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// HostFacilityRanking.Ranking - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingRanking
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostFacilityRankingFields.Ranking);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostFacilityRankingEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// HostFacilityRanking.InternetAccess - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingInternetAccess
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostFacilityRankingFields.InternetAccess);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostFacilityRankingEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// HostFacilityRanking.RankedByOrganizationRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingRankedByOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HostFacilityRankingFields.RankedByOrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostFacilityRankingEntity and ProspectsEntity over the m:1 relation they have, using the relation between the fields:
		/// HostFacilityRanking.HostId - Prospects.ProspectId
		/// </summary>
		public virtual IEntityRelation ProspectsEntityUsingHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Prospects", false);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, HostFacilityRankingFields.HostId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostFacilityRankingEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// HostFacilityRanking.RankedByRole - Role.RoleId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingRankedByRole
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role", false);
				relation.AddEntityFieldPair(RoleFields.RoleId, HostFacilityRankingFields.RankedByRole);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", true);
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
