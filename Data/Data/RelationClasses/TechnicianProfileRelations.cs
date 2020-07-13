﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: TechnicianProfile. </summary>
	public partial class TechnicianProfileRelations
	{
		/// <summary>CTor</summary>
		public TechnicianProfileRelations()
		{
		}

		/// <summary>Gets all relations of the TechnicianProfileEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.PinChangelogEntityUsingTechnicianId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingOrganizationRoleUserId);

			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TechnicianProfileEntity and PinChangelogEntity over the 1:n relation they have, using the relation between the fields:
		/// TechnicianProfile.OrganizationRoleUserId - PinChangelog.TechnicianId
		/// </summary>
		public virtual IEntityRelation PinChangelogEntityUsingTechnicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PinChangelog" , true);
				relation.AddEntityFieldPair(TechnicianProfileFields.OrganizationRoleUserId, PinChangelogFields.TechnicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TechnicianProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PinChangelogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TechnicianProfileEntity and OrganizationRoleUserEntity over the 1:1 relation they have, using the relation between the fields:
		/// TechnicianProfile.OrganizationRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "OrganizationRoleUser", false);



				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TechnicianProfileFields.OrganizationRoleUserId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TechnicianProfileEntity", true);
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