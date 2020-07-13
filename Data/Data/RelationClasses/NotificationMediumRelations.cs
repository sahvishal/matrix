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
	/// <summary>Implements the static Relations variant for the entity: NotificationMedium. </summary>
	public partial class NotificationMediumRelations
	{
		/// <summary>CTor</summary>
		public NotificationMediumRelations()
		{
		}

		/// <summary>Gets all relations of the NotificationMediumEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.NotificationEntityUsingNotificationMediumId);
			toReturn.Add(this.NotificationTypeEntityUsingNotificationMediumId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between NotificationMediumEntity and NotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// NotificationMedium.NotificationMediumId - Notification.NotificationMediumId
		/// </summary>
		public virtual IEntityRelation NotificationEntityUsingNotificationMediumId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Notification" , true);
				relation.AddEntityFieldPair(NotificationMediumFields.NotificationMediumId, NotificationFields.NotificationMediumId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationMediumEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotificationMediumEntity and NotificationTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// NotificationMedium.NotificationMediumId - NotificationType.NotificationMediumId
		/// </summary>
		public virtual IEntityRelation NotificationTypeEntityUsingNotificationMediumId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NotificationType" , true);
				relation.AddEntityFieldPair(NotificationMediumFields.NotificationMediumId, NotificationTypeFields.NotificationMediumId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationMediumEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", false);
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
