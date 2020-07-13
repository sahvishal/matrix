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
	/// <summary>Implements the static Relations variant for the entity: Territory. </summary>
	public partial class TerritoryRelations
	{
		/// <summary>CTor</summary>
		public TerritoryRelations()
		{
		}

		/// <summary>Gets all relations of the TerritoryEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventPodEntityUsingTerritoryId);
			toReturn.Add(this.HospitalPartnerTerritoryEntityUsingTerritoryId);
			toReturn.Add(this.MarketingSourceTerritoryEntityUsingTerritoryId);
			toReturn.Add(this.OrganizationRoleUserTerritoryEntityUsingTerritoryId);
			toReturn.Add(this.PodTerritoryEntityUsingTerritoryId);
			toReturn.Add(this.TerritoryEntityUsingParentTerritoryId);
			toReturn.Add(this.TerritoryPackageEntityUsingTerritoryId);
			toReturn.Add(this.TerritoryZipEntityUsingTerritoryId);
			toReturn.Add(this.FranchiseeTerritoryEntityUsingTerritoryId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.TerritoryEntityUsingTerritoryIdParentTerritoryId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and EventPodEntity over the 1:n relation they have, using the relation between the fields:
		/// Territory.TerritoryId - EventPod.TerritoryId
		/// </summary>
		public virtual IEntityRelation EventPodEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPod" , true);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, EventPodFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and HospitalPartnerTerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Territory.TerritoryId - HospitalPartnerTerritory.TerritoryId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerTerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerTerritory" , true);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, HospitalPartnerTerritoryFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerTerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and MarketingSourceTerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Territory.TerritoryId - MarketingSourceTerritory.TerritoryId
		/// </summary>
		public virtual IEntityRelation MarketingSourceTerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingSourceTerritory" , true);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, MarketingSourceTerritoryFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingSourceTerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and OrganizationRoleUserTerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Territory.TerritoryId - OrganizationRoleUserTerritory.TerritoryId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserTerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrganizationRoleUserTerritory" , true);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, OrganizationRoleUserTerritoryFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserTerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and PodTerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Territory.TerritoryId - PodTerritory.TerritoryId
		/// </summary>
		public virtual IEntityRelation PodTerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodTerritory" , true);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, PodTerritoryFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodTerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and TerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Territory.TerritoryId - Territory.ParentTerritoryId
		/// </summary>
		public virtual IEntityRelation TerritoryEntityUsingParentTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Territory_" , true);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, TerritoryFields.ParentTerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and TerritoryPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// Territory.TerritoryId - TerritoryPackage.TerritoryId
		/// </summary>
		public virtual IEntityRelation TerritoryPackageEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TerritoryPackage" , true);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, TerritoryPackageFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryPackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and TerritoryZipEntity over the 1:n relation they have, using the relation between the fields:
		/// Territory.TerritoryId - TerritoryZip.TerritoryId
		/// </summary>
		public virtual IEntityRelation TerritoryZipEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TerritoryZip" , true);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, TerritoryZipFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryZipEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and FranchiseeTerritoryEntity over the 1:1 relation they have, using the relation between the fields:
		/// Territory.TerritoryId - FranchiseeTerritory.TerritoryId
		/// </summary>
		public virtual IEntityRelation FranchiseeTerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "FranchiseeTerritory", true);


				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, FranchiseeTerritoryFields.TerritoryId);


				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FranchiseeTerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Territory.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TerritoryFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and TerritoryEntity over the m:1 relation they have, using the relation between the fields:
		/// Territory.ParentTerritoryId - Territory.TerritoryId
		/// </summary>
		public virtual IEntityRelation TerritoryEntityUsingTerritoryIdParentTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Territory", false);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, TerritoryFields.ParentTerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
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
