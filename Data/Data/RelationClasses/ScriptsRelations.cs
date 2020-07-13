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
	/// <summary>Implements the static Relations variant for the entity: Scripts. </summary>
	public partial class ScriptsRelations
	{
		/// <summary>CTor</summary>
		public ScriptsRelations()
		{
		}

		/// <summary>Gets all relations of the ScriptsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallQueueEntityUsingScriptId);

			toReturn.Add(this.ScriptTypeEntityUsingScriptTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ScriptsEntity and CallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Scripts.ScriptId - CallQueue.ScriptId
		/// </summary>
		public virtual IEntityRelation CallQueueEntityUsingScriptId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueue" , true);
				relation.AddEntityFieldPair(ScriptsFields.ScriptId, CallQueueFields.ScriptId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScriptsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ScriptsEntity and ScriptTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Scripts.ScriptTypeId - ScriptType.ScriptTypeId
		/// </summary>
		public virtual IEntityRelation ScriptTypeEntityUsingScriptTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ScriptType", false);
				relation.AddEntityFieldPair(ScriptTypeFields.ScriptTypeId, ScriptsFields.ScriptTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScriptTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScriptsEntity", true);
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
