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
	/// <summary>Implements the static Relations variant for the entity: NotificationType. </summary>
	public partial class NotificationTypeRelations
	{
		/// <summary>CTor</summary>
		public NotificationTypeRelations()
		{
		}

		/// <summary>Gets all relations of the NotificationTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EmailTemplateEntityUsingNotificationTypeId);
			toReturn.Add(this.EventCustomerNotificationEntityUsingNotificationTypeId);
			toReturn.Add(this.EventCustomerTestNotPerformedNotificationEntityUsingNotificationTypeId);
			toReturn.Add(this.NotificationEntityUsingNotificationTypeId);
			toReturn.Add(this.NotificationSubscribersEntityUsingNotificationTypeId);

			toReturn.Add(this.NotificationMediumEntityUsingNotificationMediumId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between NotificationTypeEntity and EmailTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// NotificationType.NotificationTypeId - EmailTemplate.NotificationTypeId
		/// </summary>
		public virtual IEntityRelation EmailTemplateEntityUsingNotificationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EmailTemplate" , true);
				relation.AddEntityFieldPair(NotificationTypeFields.NotificationTypeId, EmailTemplateFields.NotificationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationTypeEntity and EventCustomerNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// NotificationType.NotificationTypeId - EventCustomerNotification.NotificationTypeId
		/// </summary>
		public virtual IEntityRelation EventCustomerNotificationEntityUsingNotificationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerNotification" , true);
				relation.AddEntityFieldPair(NotificationTypeFields.NotificationTypeId, EventCustomerNotificationFields.NotificationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationTypeEntity and EventCustomerTestNotPerformedNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// NotificationType.NotificationTypeId - EventCustomerTestNotPerformedNotification.NotificationTypeId
		/// </summary>
		public virtual IEntityRelation EventCustomerTestNotPerformedNotificationEntityUsingNotificationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerTestNotPerformedNotification" , true);
				relation.AddEntityFieldPair(NotificationTypeFields.NotificationTypeId, EventCustomerTestNotPerformedNotificationFields.NotificationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerTestNotPerformedNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationTypeEntity and NotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// NotificationType.NotificationTypeId - Notification.NotificationTypeId
		/// </summary>
		public virtual IEntityRelation NotificationEntityUsingNotificationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Notification" , true);
				relation.AddEntityFieldPair(NotificationTypeFields.NotificationTypeId, NotificationFields.NotificationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationTypeEntity and NotificationSubscribersEntity over the 1:n relation they have, using the relation between the fields:
		/// NotificationType.NotificationTypeId - NotificationSubscribers.NotificationTypeId
		/// </summary>
		public virtual IEntityRelation NotificationSubscribersEntityUsingNotificationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NotificationSubscribers" , true);
				relation.AddEntityFieldPair(NotificationTypeFields.NotificationTypeId, NotificationSubscribersFields.NotificationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationSubscribersEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between NotificationTypeEntity and NotificationMediumEntity over the m:1 relation they have, using the relation between the fields:
		/// NotificationType.NotificationMediumId - NotificationMedium.NotificationMediumId
		/// </summary>
		public virtual IEntityRelation NotificationMediumEntityUsingNotificationMediumId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotificationMedium", false);
				relation.AddEntityFieldPair(NotificationMediumFields.NotificationMediumId, NotificationTypeFields.NotificationMediumId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationMediumEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between NotificationTypeEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// NotificationType.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, NotificationTypeFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", true);
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
