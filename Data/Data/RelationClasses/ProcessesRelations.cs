﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:16 AM
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
	/// <summary>Implements the static Relations variant for the entity: Processes. </summary>
	public partial class ProcessesRelations
	{
		/// <summary>CTor</summary>
		public ProcessesRelations()
		{
		}

		/// <summary>Gets all relations of the ProcessesEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ProcessActivityEntityUsingProcessId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ProcessesEntity and ProcessActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// Processes.ProcessId - ProcessActivity.ProcessId
		/// </summary>
		public virtual IEntityRelation ProcessActivityEntityUsingProcessId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProcessActivity" , true);
				relation.AddEntityFieldPair(ProcessesFields.ProcessId, ProcessActivityFields.ProcessId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProcessesEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProcessActivityEntity", false);
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
