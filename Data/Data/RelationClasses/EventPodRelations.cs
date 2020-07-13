///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: EventPod. </summary>
	public partial class EventPodRelations
	{
		/// <summary>CTor</summary>
		public EventPodRelations()
		{
		}

		/// <summary>Gets all relations of the EventPodEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventPodRoomEntityUsingEventPodId);

			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.PodDetailsEntityUsingPodId);
			toReturn.Add(this.TerritoryEntityUsingTerritoryId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EventPodEntity and EventPodRoomEntity over the 1:n relation they have, using the relation between the fields:
		/// EventPod.EventPodId - EventPodRoom.EventPodId
		/// </summary>
		public virtual IEntityRelation EventPodRoomEntityUsingEventPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPodRoom" , true);
				relation.AddEntityFieldPair(EventPodFields.EventPodId, EventPodRoomFields.EventPodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodRoomEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between EventPodEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPod.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, EventPodFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventPodEntity and PodDetailsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPod.PodId - PodDetails.PodId
		/// </summary>
		public virtual IEntityRelation PodDetailsEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PodDetails", false);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, EventPodFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventPodEntity and TerritoryEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPod.TerritoryId - Territory.TerritoryId
		/// </summary>
		public virtual IEntityRelation TerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Territory", false);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, EventPodFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodEntity", true);
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
