///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:41
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
	/// <summary>Implements the static Relations variant for the entity: FillEventCallQueueCriteriaAssignment. </summary>
	public partial class FillEventCallQueueCriteriaAssignmentRelations
	{
		/// <summary>CTor</summary>
		public FillEventCallQueueCriteriaAssignmentRelations()
		{
		}

		/// <summary>Gets all relations of the FillEventCallQueueCriteriaAssignmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.FillEventCallQueueEntityUsingFillEventCallQueueId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingCriteriaId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between FillEventCallQueueCriteriaAssignmentEntity and FillEventCallQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// FillEventCallQueueCriteriaAssignment.FillEventCallQueueId - FillEventCallQueue.Id
		/// </summary>
		public virtual IEntityRelation FillEventCallQueueEntityUsingFillEventCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FillEventCallQueue", false);
				relation.AddEntityFieldPair(FillEventCallQueueFields.Id, FillEventCallQueueCriteriaAssignmentFields.FillEventCallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FillEventCallQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FillEventCallQueueCriteriaAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between FillEventCallQueueCriteriaAssignmentEntity and HealthPlanCallQueueCriteriaEntity over the m:1 relation they have, using the relation between the fields:
		/// FillEventCallQueueCriteriaAssignment.CriteriaId - HealthPlanCallQueueCriteria.Id
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HealthPlanCallQueueCriteria", false);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, FillEventCallQueueCriteriaAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FillEventCallQueueCriteriaAssignmentEntity", true);
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
