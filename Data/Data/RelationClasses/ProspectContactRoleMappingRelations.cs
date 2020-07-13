﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: ProspectContactRoleMapping. </summary>
	public partial class ProspectContactRoleMappingRelations
	{
		/// <summary>CTor</summary>
		public ProspectContactRoleMappingRelations()
		{
		}

		/// <summary>Gets all relations of the ProspectContactRoleMappingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ProspectContactEntityUsingProspectContactId);
			toReturn.Add(this.ProspectContactRoleEntityUsingProspectContactRoleId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ProspectContactRoleMappingEntity and ProspectContactEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectContactRoleMapping.ProspectContactId - ProspectContact.ProspectContactId
		/// </summary>
		public virtual IEntityRelation ProspectContactEntityUsingProspectContactId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ProspectContact", false);
				relation.AddEntityFieldPair(ProspectContactFields.ProspectContactId, ProspectContactRoleMappingFields.ProspectContactId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectContactEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectContactRoleMappingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProspectContactRoleMappingEntity and ProspectContactRoleEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectContactRoleMapping.ProspectContactRoleId - ProspectContactRole.ProspectContactRoleId
		/// </summary>
		public virtual IEntityRelation ProspectContactRoleEntityUsingProspectContactRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ProspectContactRole", false);
				relation.AddEntityFieldPair(ProspectContactRoleFields.ProspectContactRoleId, ProspectContactRoleMappingFields.ProspectContactRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectContactRoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectContactRoleMappingEntity", true);
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
