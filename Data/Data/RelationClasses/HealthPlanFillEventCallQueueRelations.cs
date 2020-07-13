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
	/// <summary>Implements the static Relations variant for the entity: HealthPlanFillEventCallQueue. </summary>
	public partial class HealthPlanFillEventCallQueueRelations
	{
		/// <summary>CTor</summary>
		public HealthPlanFillEventCallQueueRelations()
		{
		}

		/// <summary>Gets all relations of the HealthPlanFillEventCallQueueEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingCriteriaId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HealthPlanFillEventCallQueueEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanFillEventCallQueue.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, HealthPlanFillEventCallQueueFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanFillEventCallQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanFillEventCallQueueEntity and HealthPlanCallQueueCriteriaEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanFillEventCallQueue.CriteriaId - HealthPlanCallQueueCriteria.Id
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HealthPlanCallQueueCriteria", false);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, HealthPlanFillEventCallQueueFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanFillEventCallQueueEntity", true);
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
