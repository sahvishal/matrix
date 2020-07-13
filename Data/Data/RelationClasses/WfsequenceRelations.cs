///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:15 AM
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
	/// <summary>Implements the static Relations variant for the entity: Wfsequence. </summary>
	public partial class WfsequenceRelations
	{
		/// <summary>CTor</summary>
		public WfsequenceRelations()
		{
		}

		/// <summary>Gets all relations of the WfsequenceEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ProspectActivityDetailsEntityUsingWfsequenceId);

			toReturn.Add(this.WfEntityUsingWfid);
			toReturn.Add(this.WfstageEntityUsingWfstageId);
			toReturn.Add(this.WfstageTriggerEntityUsingWfstageTriggerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between WfsequenceEntity and ProspectActivityDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Wfsequence.WfsequenceId - ProspectActivityDetails.WfsequenceId
		/// </summary>
		public virtual IEntityRelation ProspectActivityDetailsEntityUsingWfsequenceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectActivityDetails" , true);
				relation.AddEntityFieldPair(WfsequenceFields.WfsequenceId, ProspectActivityDetailsFields.WfsequenceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfsequenceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectActivityDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between WfsequenceEntity and WfEntity over the m:1 relation they have, using the relation between the fields:
		/// Wfsequence.Wfid - Wf.Wfid
		/// </summary>
		public virtual IEntityRelation WfEntityUsingWfid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Wf", false);
				relation.AddEntityFieldPair(WfFields.Wfid, WfsequenceFields.Wfid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfsequenceEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between WfsequenceEntity and WfstageEntity over the m:1 relation they have, using the relation between the fields:
		/// Wfsequence.WfstageId - Wfstage.WfstageId
		/// </summary>
		public virtual IEntityRelation WfstageEntityUsingWfstageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Wfstage", false);
				relation.AddEntityFieldPair(WfstageFields.WfstageId, WfsequenceFields.WfstageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfstageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfsequenceEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between WfsequenceEntity and WfstageTriggerEntity over the m:1 relation they have, using the relation between the fields:
		/// Wfsequence.WfstageTriggerId - WfstageTrigger.WorkFlowStageTriggerId
		/// </summary>
		public virtual IEntityRelation WfstageTriggerEntityUsingWfstageTriggerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "WfstageTrigger", false);
				relation.AddEntityFieldPair(WfstageTriggerFields.WorkFlowStageTriggerId, WfsequenceFields.WfstageTriggerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfstageTriggerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfsequenceEntity", true);
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
