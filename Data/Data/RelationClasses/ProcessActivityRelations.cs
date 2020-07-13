///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:17 AM
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
	/// <summary>Implements the static Relations variant for the entity: ProcessActivity. </summary>
	public partial class ProcessActivityRelations
	{
		/// <summary>CTor</summary>
		public ProcessActivityRelations()
		{
		}

		/// <summary>Gets all relations of the ProcessActivityEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ActivityEntityUsingActivityId);

			toReturn.Add(this.ProcessesEntityUsingProcessId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ProcessActivityEntity and ActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// ProcessActivity.ProcessActivityId - Activity.ActivityId
		/// </summary>
		public virtual IEntityRelation ActivityEntityUsingActivityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Activity" , true);
				relation.AddEntityFieldPair(ProcessActivityFields.ProcessActivityId, ActivityFields.ActivityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProcessActivityEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActivityEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ProcessActivityEntity and ProcessesEntity over the m:1 relation they have, using the relation between the fields:
		/// ProcessActivity.ProcessId - Processes.ProcessId
		/// </summary>
		public virtual IEntityRelation ProcessesEntityUsingProcessId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Processes", false);
				relation.AddEntityFieldPair(ProcessesFields.ProcessId, ProcessActivityFields.ProcessId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProcessesEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProcessActivityEntity", true);
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
