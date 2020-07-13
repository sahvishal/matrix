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
	/// <summary>Implements the static Relations variant for the entity: RescheduleCancelDisposition. </summary>
	public partial class RescheduleCancelDispositionRelations
	{
		/// <summary>CTor</summary>
		public RescheduleCancelDispositionRelations()
		{
		}

		/// <summary>Gets all relations of the RescheduleCancelDispositionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventAppointmentCancellationLogEntityUsingSubReasonId);
			toReturn.Add(this.EventAppointmentChangeLogEntityUsingSubReasonId);

			toReturn.Add(this.LookupEntityUsingLookupId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between RescheduleCancelDispositionEntity and EventAppointmentCancellationLogEntity over the 1:n relation they have, using the relation between the fields:
		/// RescheduleCancelDisposition.Id - EventAppointmentCancellationLog.SubReasonId
		/// </summary>
		public virtual IEntityRelation EventAppointmentCancellationLogEntityUsingSubReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentCancellationLog" , true);
				relation.AddEntityFieldPair(RescheduleCancelDispositionFields.Id, EventAppointmentCancellationLogFields.SubReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RescheduleCancelDispositionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RescheduleCancelDispositionEntity and EventAppointmentChangeLogEntity over the 1:n relation they have, using the relation between the fields:
		/// RescheduleCancelDisposition.Id - EventAppointmentChangeLog.SubReasonId
		/// </summary>
		public virtual IEntityRelation EventAppointmentChangeLogEntityUsingSubReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentChangeLog" , true);
				relation.AddEntityFieldPair(RescheduleCancelDispositionFields.Id, EventAppointmentChangeLogFields.SubReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RescheduleCancelDispositionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentChangeLogEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between RescheduleCancelDispositionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// RescheduleCancelDisposition.LookupId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingLookupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, RescheduleCancelDispositionFields.LookupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RescheduleCancelDispositionEntity", true);
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
