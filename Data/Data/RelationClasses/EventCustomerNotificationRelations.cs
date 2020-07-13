///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
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
	/// <summary>Implements the static Relations variant for the entity: EventCustomerNotification. </summary>
	public partial class EventCustomerNotificationRelations
	{
		/// <summary>CTor</summary>
		public EventCustomerNotificationRelations()
		{
		}

		/// <summary>Gets all relations of the EventCustomerNotificationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.NotificationEntityUsingNotificationId);
			toReturn.Add(this.NotificationTypeEntityUsingNotificationTypeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EventCustomerNotificationEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerNotification.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerNotificationFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerNotificationEntity and NotificationEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerNotification.NotificationId - Notification.NotificationId
		/// </summary>
		public virtual IEntityRelation NotificationEntityUsingNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Notification", false);
				relation.AddEntityFieldPair(NotificationFields.NotificationId, EventCustomerNotificationFields.NotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerNotificationEntity and NotificationTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerNotification.NotificationTypeId - NotificationType.NotificationTypeId
		/// </summary>
		public virtual IEntityRelation NotificationTypeEntityUsingNotificationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotificationType", false);
				relation.AddEntityFieldPair(NotificationTypeFields.NotificationTypeId, EventCustomerNotificationFields.NotificationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerNotificationEntity", true);
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
