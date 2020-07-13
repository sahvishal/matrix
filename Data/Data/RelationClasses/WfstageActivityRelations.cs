///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:05 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: WfstageActivity. </summary>
	public partial class WfstageActivityRelations
	{
		/// <summary>CTor</summary>
		public WfstageActivityRelations()
		{
		}

		/// <summary>Gets all relations of the WfstageActivityEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.WfactivityEntityUsingWfactivityId);
			toReturn.Add(this.WfstageEntityUsingWfstageId);
			toReturn.Add(this.WorkFlowActivityEntityUsingWfactivityId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between WfstageActivityEntity and WfactivityEntity over the m:1 relation they have, using the relation between the fields:
		/// WfstageActivity.WfactivityId - Wfactivity.WfactivityId
		/// </summary>
		public virtual IEntityRelation WfactivityEntityUsingWfactivityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Wfactivity", false);
				relation.AddEntityFieldPair(WfactivityFields.WfactivityId, WfstageActivityFields.WfactivityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfactivityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfstageActivityEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between WfstageActivityEntity and WfstageEntity over the m:1 relation they have, using the relation between the fields:
		/// WfstageActivity.WfstageId - Wfstage.WfstageId
		/// </summary>
		public virtual IEntityRelation WfstageEntityUsingWfstageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Wfstage", false);
				relation.AddEntityFieldPair(WfstageFields.WfstageId, WfstageActivityFields.WfstageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfstageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfstageActivityEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between WfstageActivityEntity and WorkFlowActivityEntity over the m:1 relation they have, using the relation between the fields:
		/// WfstageActivity.WfactivityId - WorkFlowActivity.WfactivityId
		/// </summary>
		public virtual IEntityRelation WorkFlowActivityEntityUsingWfactivityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "WorkFlowActivity", false);
				relation.AddEntityFieldPair(WorkFlowActivityFields.WfactivityId, WfstageActivityFields.WfactivityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WorkFlowActivityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfstageActivityEntity", true);
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
