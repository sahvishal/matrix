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
	/// <summary>Implements the static Relations variant for the entity: ScriptType. </summary>
	public partial class ScriptTypeRelations
	{
		/// <summary>CTor</summary>
		public ScriptTypeRelations()
		{
		}

		/// <summary>Gets all relations of the ScriptTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ScriptsEntityUsingScriptTypeId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ScriptTypeEntity and ScriptsEntity over the 1:n relation they have, using the relation between the fields:
		/// ScriptType.ScriptTypeId - Scripts.ScriptTypeId
		/// </summary>
		public virtual IEntityRelation ScriptsEntityUsingScriptTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Scripts" , true);
				relation.AddEntityFieldPair(ScriptTypeFields.ScriptTypeId, ScriptsFields.ScriptTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScriptTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScriptsEntity", false);
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
