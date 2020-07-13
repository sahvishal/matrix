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
	/// <summary>Implements the static Relations variant for the entity: RoleAccessControlObject. </summary>
	public partial class RoleAccessControlObjectRelations
	{
		/// <summary>CTor</summary>
		public RoleAccessControlObjectRelations()
		{
		}

		/// <summary>Gets all relations of the RoleAccessControlObjectEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AccessControlObjectEntityUsingAccessControlObjectId);
			toReturn.Add(this.LookupEntityUsingPermissionTypeId);
			toReturn.Add(this.LookupEntityUsingScopeId);
			toReturn.Add(this.RoleEntityUsingRoleId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between RoleAccessControlObjectEntity and AccessControlObjectEntity over the m:1 relation they have, using the relation between the fields:
		/// RoleAccessControlObject.AccessControlObjectId - AccessControlObject.Id
		/// </summary>
		public virtual IEntityRelation AccessControlObjectEntityUsingAccessControlObjectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AccessControlObject", false);
				relation.AddEntityFieldPair(AccessControlObjectFields.Id, RoleAccessControlObjectFields.AccessControlObjectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAccessControlObjectEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RoleAccessControlObjectEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// RoleAccessControlObject.PermissionTypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingPermissionTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, RoleAccessControlObjectFields.PermissionTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAccessControlObjectEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RoleAccessControlObjectEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// RoleAccessControlObject.ScopeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingScopeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, RoleAccessControlObjectFields.ScopeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAccessControlObjectEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RoleAccessControlObjectEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// RoleAccessControlObject.RoleId - Role.RoleId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role", false);
				relation.AddEntityFieldPair(RoleFields.RoleId, RoleAccessControlObjectFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAccessControlObjectEntity", true);
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
