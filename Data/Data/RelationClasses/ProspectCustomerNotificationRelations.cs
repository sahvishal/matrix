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
	/// <summary>Implements the static Relations variant for the entity: ProspectCustomerNotification. </summary>
	public partial class ProspectCustomerNotificationRelations
	{
		/// <summary>CTor</summary>
		public ProspectCustomerNotificationRelations()
		{
		}

		/// <summary>Gets all relations of the ProspectCustomerNotificationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.NotificationEntityUsingNotificationId);
			toReturn.Add(this.ProspectCustomerEntityUsingProspectCustomerId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerNotificationEntity and NotificationEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectCustomerNotification.NotificationId - Notification.NotificationId
		/// </summary>
		public virtual IEntityRelation NotificationEntityUsingNotificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Notification", false);
				relation.AddEntityFieldPair(NotificationFields.NotificationId, ProspectCustomerNotificationFields.NotificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerNotificationEntity and ProspectCustomerEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectCustomerNotification.ProspectCustomerId - ProspectCustomer.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ProspectCustomer", false);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, ProspectCustomerNotificationFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerNotificationEntity", true);
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
