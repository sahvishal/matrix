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
	/// <summary>Implements the static Relations variant for the entity: AccessObjectScopeOption. </summary>
	public partial class AccessObjectScopeOptionRelations
	{
		/// <summary>CTor</summary>
		public AccessObjectScopeOptionRelations()
		{
		}

		/// <summary>Gets all relations of the AccessObjectScopeOptionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AccessControlObjectEntityUsingAccessControlObjectId);
			toReturn.Add(this.LookupEntityUsingScopeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AccessObjectScopeOptionEntity and AccessControlObjectEntity over the m:1 relation they have, using the relation between the fields:
		/// AccessObjectScopeOption.AccessControlObjectId - AccessControlObject.Id
		/// </summary>
		public virtual IEntityRelation AccessControlObjectEntityUsingAccessControlObjectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AccessControlObject", false);
				relation.AddEntityFieldPair(AccessControlObjectFields.Id, AccessObjectScopeOptionFields.AccessControlObjectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessControlObjectEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessObjectScopeOptionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccessObjectScopeOptionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// AccessObjectScopeOption.ScopeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingScopeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, AccessObjectScopeOptionFields.ScopeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessObjectScopeOptionEntity", true);
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
