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
	/// <summary>Implements the static Relations variant for the entity: EventCustomerTestNotPerformedNotification. </summary>
	public partial class EventCustomerTestNotPerformedNotificationRelations
	{
		/// <summary>CTor</summary>
		public EventCustomerTestNotPerformedNotificationRelations()
		{
		}

		/// <summary>Gets all relations of the EventCustomerTestNotPerformedNotificationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.NotificationTypeEntityUsingNotificationTypeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EventCustomerTestNotPerformedNotificationEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerTestNotPerformedNotification.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerTestNotPerformedNotificationFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerTestNotPerformedNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerTestNotPerformedNotificationEntity and NotificationTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerTestNotPerformedNotification.NotificationTypeId - NotificationType.NotificationTypeId
		/// </summary>
		public virtual IEntityRelation NotificationTypeEntityUsingNotificationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotificationType", false);
				relation.AddEntityFieldPair(NotificationTypeFields.NotificationTypeId, EventCustomerTestNotPerformedNotificationFields.NotificationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerTestNotPerformedNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerTestNotPerformedNotificationEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerTestNotPerformedNotification.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerTestNotPerformedNotificationFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerTestNotPerformedNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerTestNotPerformedNotificationEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerTestNotPerformedNotification.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, EventCustomerTestNotPerformedNotificationFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerTestNotPerformedNotificationEntity", true);
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
