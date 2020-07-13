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
	/// <summary>Implements the static Relations variant for the entity: AccessControlObject. </summary>
	public partial class AccessControlObjectRelations
	{
		/// <summary>CTor</summary>
		public AccessControlObjectRelations()
		{
		}

		/// <summary>Gets all relations of the AccessControlObjectEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccessControlObjectEntityUsingParentId);
			toReturn.Add(this.AccessControlObjectUrlEntityUsingAccessControlObjectId);
			toReturn.Add(this.AccessObjectScopeOptionEntityUsingAccessControlObjectId);
			toReturn.Add(this.RoleAccessControlObjectEntityUsingAccessControlObjectId);
			toReturn.Add(this.RolePermisibleAccessControlObjectEntityUsingAccessControlObjectId);

			toReturn.Add(this.AccessControlObjectEntityUsingIdParentId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AccessControlObjectEntity and AccessControlObjectEntity over the 1:n relation they have, using the relation between the fields:
		/// AccessControlObject.Id - AccessControlObject.ParentId
		/// </summary>
		public virtual IEntityRelation AccessControlObjectEntityUsingParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccessControlObject_" , true);
				relation.AddEntityFieldPair(AccessControlObjectFields.Id, AccessControlObjectFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccessControlObjectEntity and AccessControlObjectUrlEntity over the 1:n relation they have, using the relation between the fields:
		/// AccessControlObject.Id - AccessControlObjectUrl.AccessControlObjectId
		/// </summary>
		public virtual IEntityRelation AccessControlObjectUrlEntityUsingAccessControlObjectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccessControlObjectUrl" , true);
				relation.AddEntityFieldPair(AccessControlObjectFields.Id, AccessControlObjectUrlFields.AccessControlObjectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectUrlEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccessControlObjectEntity and AccessObjectScopeOptionEntity over the 1:n relation they have, using the relation between the fields:
		/// AccessControlObject.Id - AccessObjectScopeOption.AccessControlObjectId
		/// </summary>
		public virtual IEntityRelation AccessObjectScopeOptionEntityUsingAccessControlObjectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccessObjectScopeOption" , true);
				relation.AddEntityFieldPair(AccessControlObjectFields.Id, AccessObjectScopeOptionFields.AccessControlObjectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessObjectScopeOptionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccessControlObjectEntity and RoleAccessControlObjectEntity over the 1:n relation they have, using the relation between the fields:
		/// AccessControlObject.Id - RoleAccessControlObject.AccessControlObjectId
		/// </summary>
		public virtual IEntityRelation RoleAccessControlObjectEntityUsingAccessControlObjectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleAccessControlObject" , true);
				relation.AddEntityFieldPair(AccessControlObjectFields.Id, RoleAccessControlObjectFields.AccessControlObjectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAccessControlObjectEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccessControlObjectEntity and RolePermisibleAccessControlObjectEntity over the 1:n relation they have, using the relation between the fields:
		/// AccessControlObject.Id - RolePermisibleAccessControlObject.AccessControlObjectId
		/// </summary>
		public virtual IEntityRelation RolePermisibleAccessControlObjectEntityUsingAccessControlObjectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RolePermisibleAccessControlObject" , true);
				relation.AddEntityFieldPair(AccessControlObjectFields.Id, RolePermisibleAccessControlObjectFields.AccessControlObjectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RolePermisibleAccessControlObjectEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AccessControlObjectEntity and AccessControlObjectEntity over the m:1 relation they have, using the relation between the fields:
		/// AccessControlObject.ParentId - AccessControlObject.Id
		/// </summary>
		public virtual IEntityRelation AccessControlObjectEntityUsingIdParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AccessControlObject", false);
				relation.AddEntityFieldPair(AccessControlObjectFields.Id, AccessControlObjectFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", true);
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
