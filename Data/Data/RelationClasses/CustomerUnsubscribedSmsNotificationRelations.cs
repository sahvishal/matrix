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
	/// <summary>Implements the static Relations variant for the entity: CustomerUnsubscribedSmsNotification. </summary>
	public partial class CustomerUnsubscribedSmsNotificationRelations
	{
		/// <summary>CTor</summary>
		public CustomerUnsubscribedSmsNotificationRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerUnsubscribedSmsNotificationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.LookupEntityUsingStatusId);
			toReturn.Add(this.SmsReceivedEntityUsingSmsReceivedId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CustomerUnsubscribedSmsNotificationEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerUnsubscribedSmsNotification.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerUnsubscribedSmsNotificationFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerUnsubscribedSmsNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerUnsubscribedSmsNotificationEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerUnsubscribedSmsNotification.StatusId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerUnsubscribedSmsNotificationFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerUnsubscribedSmsNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerUnsubscribedSmsNotificationEntity and SmsReceivedEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerUnsubscribedSmsNotification.SmsReceivedId - SmsReceived.Id
		/// </summary>
		public virtual IEntityRelation SmsReceivedEntityUsingSmsReceivedId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SmsReceived", false);
				relation.AddEntityFieldPair(SmsReceivedFields.Id, CustomerUnsubscribedSmsNotificationFields.SmsReceivedId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SmsReceivedEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerUnsubscribedSmsNotificationEntity", true);
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
