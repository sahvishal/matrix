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
	/// <summary>Implements the static Relations variant for the entity: NoShowCallQueueCriteriaAssignment. </summary>
	public partial class NoShowCallQueueCriteriaAssignmentRelations
	{
		/// <summary>CTor</summary>
		public NoShowCallQueueCriteriaAssignmentRelations()
		{
		}

		/// <summary>Gets all relations of the NoShowCallQueueCriteriaAssignmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingCriteriaId);
			toReturn.Add(this.NoShowCallQueueEntityUsingNoShowCallQueueId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between NoShowCallQueueCriteriaAssignmentEntity and HealthPlanCallQueueCriteriaEntity over the m:1 relation they have, using the relation between the fields:
		/// NoShowCallQueueCriteriaAssignment.CriteriaId - HealthPlanCallQueueCriteria.Id
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HealthPlanCallQueueCriteria", false);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, NoShowCallQueueCriteriaAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoShowCallQueueCriteriaAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between NoShowCallQueueCriteriaAssignmentEntity and NoShowCallQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// NoShowCallQueueCriteriaAssignment.NoShowCallQueueId - NoShowCallQueue.Id
		/// </summary>
		public virtual IEntityRelation NoShowCallQueueEntityUsingNoShowCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NoShowCallQueue", false);
				relation.AddEntityFieldPair(NoShowCallQueueFields.Id, NoShowCallQueueCriteriaAssignmentFields.NoShowCallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoShowCallQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoShowCallQueueCriteriaAssignmentEntity", true);
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
