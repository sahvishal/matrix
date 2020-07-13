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
	/// <summary>Implements the static Relations variant for the entity: Notification. </summary>
	public partial class NotificationRelations
	{
		/// <summary>CTor</summary>
		public NotificationRelations()
		{
		}

		/// <summary>Gets all relations of the NotificationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventCustomerNotificationEntityUsingNotificationId);
			toReturn.Add(this.EventNotificationEntityUsingNotificationId);
			toReturn.Add(this.ProspectCustomerNotificationEntityUsingNotificationId);
			toReturn.Add(this.NotificationEmailEntityUsingNotificationEmailId);
			toReturn.Add(this.NotificationPhoneEntityUsingNotificationPhoneId);
			toReturn.Add(this.NotificationMediumEntityUsingNotificationMediumId);
			toReturn.Add(this.NotificationTypeEntityUsingNotificationTypeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between NotificationEntity and EventCustomerNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Notification.NotificationId - EventCustomerNotification.NotificationId
		/// </summary>
		public virtual IEntityRelation EventCustomerNotificationEntityUsingNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerNotification" , true);
				relation.AddEntityFieldPair(NotificationFields.NotificationId, EventCustomerNotificationFields.NotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationEntity and EventNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Notification.NotificationId - EventNotification.NotificationId
		/// </summary>
		public virtual IEntityRelation EventNotificationEntityUsingNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventNotification" , true);
				relation.AddEntityFieldPair(NotificationFields.NotificationId, EventNotificationFields.NotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationEntity and ProspectCustomerNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Notification.NotificationId - ProspectCustomerNotification.NotificationId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerNotificationEntityUsingNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectCustomerNotification" , true);
				relation.AddEntityFieldPair(NotificationFields.NotificationId, ProspectCustomerNotificationFields.NotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationEntity and NotificationEmailEntity over the 1:1 relation they have, using the relation between the fields:
		/// Notification.NotificationId - NotificationEmail.NotificationEmailId
		/// </summary>
		public virtual IEntityRelation NotificationEmailEntityUsingNotificationEmailId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "NotificationEmail", true);

				relation.AddEntityFieldPair(NotificationFields.NotificationId, NotificationEmailFields.NotificationEmailId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEmailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationEntity and NotificationPhoneEntity over the 1:1 relation they have, using the relation between the fields:
		/// Notification.NotificationId - NotificationPhone.NotificationPhoneId
		/// </summary>
		public virtual IEntityRelation NotificationPhoneEntityUsingNotificationPhoneId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "NotificationPhone", true);

				relation.AddEntityFieldPair(NotificationFields.NotificationId, NotificationPhoneFields.NotificationPhoneId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationPhoneEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationEntity and NotificationMediumEntity over the m:1 relation they have, using the relation between the fields:
		/// Notification.NotificationMediumId - NotificationMedium.NotificationMediumId
		/// </summary>
		public virtual IEntityRelation NotificationMediumEntityUsingNotificationMediumId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotificationMedium", false);
				relation.AddEntityFieldPair(NotificationMediumFields.NotificationMediumId, NotificationFields.NotificationMediumId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationMediumEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between NotificationEntity and NotificationTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Notification.NotificationTypeId - NotificationType.NotificationTypeId
		/// </summary>
		public virtual IEntityRelation NotificationTypeEntityUsingNotificationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotificationType", false);
				relation.AddEntityFieldPair(NotificationTypeFields.NotificationTypeId, NotificationFields.NotificationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between NotificationEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Notification.RequestedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, NotificationFields.RequestedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", true);
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
