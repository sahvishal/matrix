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
	/// <summary>Implements the static Relations variant for the entity: IncidentalFindings. </summary>
	public partial class IncidentalFindingsRelations
	{
		/// <summary>CTor</summary>
		public IncidentalFindingsRelations()
		{
		}

		/// <summary>Gets all relations of the IncidentalFindingsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerEventTestIncidentalFindingEntityUsingIncidentalFindingId);
			toReturn.Add(this.IflocationMasterEntityUsingIncidentalFindingsId);
			toReturn.Add(this.IncidentalFindingIncidentalFindingReadingGroupEntityUsingIncidentalFindingId);
			toReturn.Add(this.TestIncidentalFindingEntityUsingIncidentalFindingId);

			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingsEntity and CustomerEventTestIncidentalFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// IncidentalFindings.IncidentalFindingsId - CustomerEventTestIncidentalFinding.IncidentalFindingId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestIncidentalFindingEntityUsingIncidentalFindingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestIncidentalFinding" , true);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, CustomerEventTestIncidentalFindingFields.IncidentalFindingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingsEntity and IflocationMasterEntity over the 1:n relation they have, using the relation between the fields:
		/// IncidentalFindings.IncidentalFindingsId - IflocationMaster.IncidentalFindingsId
		/// </summary>
		public virtual IEntityRelation IflocationMasterEntityUsingIncidentalFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "IflocationMaster" , true);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, IflocationMasterFields.IncidentalFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IflocationMasterEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingsEntity and IncidentalFindingIncidentalFindingReadingGroupEntity over the 1:n relation they have, using the relation between the fields:
		/// IncidentalFindings.IncidentalFindingsId - IncidentalFindingIncidentalFindingReadingGroup.IncidentalFindingId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingIncidentalFindingReadingGroupEntityUsingIncidentalFindingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "IncidentalFindingIncidentalFindingReadingGroup" , true);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, IncidentalFindingIncidentalFindingReadingGroupFields.IncidentalFindingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingIncidentalFindingReadingGroupEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingsEntity and TestIncidentalFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// IncidentalFindings.IncidentalFindingsId - TestIncidentalFinding.IncidentalFindingId
		/// </summary>
		public virtual IEntityRelation TestIncidentalFindingEntityUsingIncidentalFindingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestIncidentalFinding" , true);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, TestIncidentalFindingFields.IncidentalFindingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestIncidentalFindingEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// IncidentalFindings.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, IncidentalFindingsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", true);
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
